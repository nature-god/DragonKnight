using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GolbinManager : MonsterManager {

	// Use this for initialization
	void Start () {
		Monster = new Golblin(MonsterName,Gender,Race,Level,
							Force_attack,Force_defense,Force_hit,Force_critical,Force_Probability,
							Magic_attack,Magic_defense,Magic_hit,Magic_critical,Magic_Probability,
							Health,Magic,Move_speed,Dodge,Health,Magic);
		AllSkills = new SkillManager[MonsterSkills.childCount];
		for(int i=0;i<MonsterSkills.childCount ;i++)
		{
			AllSkills[i] = MonsterSkills.GetChild(i).GetComponent<SkillManager>();
		}
		Monster.OnHealthChange = OnHealthChange;
		Monster.OnMagicChange =OnMagicChange;
		OnHealthChange(Monster.Current_health,Health);
		OnMagicChange(Monster.Current_magic,Magic);
	}

	void Update () {
		switch (_MonsterStatus)
		{
			case MonsterStatus.Normal:
			{
				break;
			}
			case MonsterStatus.Attack:
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position,AttackTarget.position,Move_speed*Time.deltaTime);
				break;
			}
			case MonsterStatus.Escape:
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position,-1.0f*AttackTarget.position,0.5f*Move_speed*Time.deltaTime);
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
			_MonsterStatus = MonsterStatus.Attack;
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

	void OnHealthChange(int current,int max)
	{
		HealthSlider.value = 1.0f*current/max;
	}
	void OnMagicChange(int current,int max)
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
}
