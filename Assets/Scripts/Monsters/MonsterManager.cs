using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour {

	public string MonsterName;
	public int Gender;
	public string Race;
	public int Level;
	public int Force_attack;
	public int Force_defense;
	public int Force_hit;
	public int Force_critical;
	public int Force_Probability;
	public int Magic_attack;
	public int Magic_defense;
	public int Magic_hit;
	public int Magic_critical;
	public int Magic_Probability;

	public int Health;
	public int Magic;
	public int Move_speed;
	public int Dodge;

	public Role Monster;
	public Slider HealthSlider;
	public Slider MagicSlider;
	public Transform MonsterSkills;
	public SkillManager[] AllSkills;
	public enum MonsterStatus
	{
		Normal = 0,
		Attack = 1,
		Escape = 2,
		Move = 3
	};
	public MonsterStatus _MonsterStatus;
	public Transform AttackTarget;
	public BoxCollider2D AttackRange;
	public Animator Anim;

	private Vector3 lastFramePos;
	void Awake()
	{
		lastFramePos = this.transform.position;
	}

	void Update () {
		SetAnimation(lastFramePos);
		lastFramePos = this.transform.position;
		switch (_MonsterStatus)
		{
			case MonsterStatus.Normal:
			{
				break;
			}
			case MonsterStatus.Move:
			{
				AttackRange.enabled = true;
				this.transform.position = Vector3.MoveTowards(this.transform.position,AttackTarget.position,Move_speed*Time.deltaTime);
				break;
			}
			case MonsterStatus.Escape:
			{
				AttackRange.enabled = false;
				for(int i = 0;i<AllSkills.Length;i++)
				{
					if(!AllSkills[i].IsCooling)
					{
						_MonsterStatus = MonsterStatus.Move;
						return;
					}
				}
				this.transform.position = Vector3.MoveTowards(this.transform.position,2.0f*this.transform.position - 1.0f*AttackTarget.position,0.5f*Move_speed*Time.deltaTime);
				break;
			}
			case MonsterStatus.Attack:
			{
				for(int i = 0;i<AllSkills.Length;i++)
				{
					if(AllSkills[i].IsCooling)
					{
						continue;
					}
					else
					{
						StartCoroutine(AllSkills[i].UseSkill(0.2f));
						return;
					}
				}
				_MonsterStatus = MonsterStatus.Escape;
				break;
			}
			default:
			{
				break;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D tmp)
	{
		if(tmp.gameObject.CompareTag("Player"))
		{
			AttackTarget = tmp.gameObject.transform;
			_MonsterStatus = MonsterStatus.Move;
		}
	}
	void OnTriggerExit2D(Collider2D tmp)
	{
		if(tmp.gameObject.CompareTag("Player"))
		{
			AttackTarget = null;
			_MonsterStatus = MonsterStatus.Normal;
		}
	}

	protected void OnHealthChange(int current,int max)
	{
		HealthSlider.value = 1.0f*current/max;
	}
	protected void OnMagicChange(int current,int max)
	{
		if(max == 0)
		{
			MagicSlider.value = 0;
		}
		else
		{
			MagicSlider.value = 1.0f*current/max;
		}
	}

	private void SetAnimation(Vector3 previousFram)
	{
		if(this.transform.position.x - previousFram.x > 0.0f)
		{
			if(this.transform.position.y - previousFram.y > 0.0f)
			{
				Anim.SetFloat("Vertical",0.0f);
				Anim.SetFloat("Horizontal",1.0f);
			}
			else
			{
				Anim.SetFloat("Vertical",1.0f);
				Anim.SetFloat("Horizontal",0.0f);
			}
		}
		else
		{
			if(this.transform.position.y - previousFram.y > 0.0f)
			{
				Anim.SetFloat("Vertical",0.0f);
				Anim.SetFloat("Horizontal",-1.0f);
			}
			else
			{
				Anim.SetFloat("Vertical",-1.0f);
				Anim.SetFloat("Horizontal",0.0f);
			}
		}
	}
}
