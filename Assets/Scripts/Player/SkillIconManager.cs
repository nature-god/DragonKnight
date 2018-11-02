using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconManager : MonoBehaviour {

	public Skill skill;
	public Image CoolingImage;
	public Sprite SkillIcon;
	public GameObject SkillEffect;
	protected Animator anim;
	public delegate void OnUseSkill();
	public OnUseSkill UseSkill;
	protected float CoolingTime;
	public bool isCooling;
	protected BoxCollider2D boxCollider2D;
	private float clockTimer;
	public float ClockTimer
	{
		set
		{
			if(value<=0.0f)
			{
				clockTimer = 0.0f;
				CoolingImage.fillAmount = 1;
			}
			else if(value >= CoolingTime)
			{
				isCooling = false;
				clockTimer = 0.0f;
				CoolingImage.fillAmount = 0;
			}
			else
			{
				clockTimer = value;
				CoolingImage.fillAmount = 1 - clockTimer/CoolingTime;
			}
		}
		get
		{
			return clockTimer;
		}
	}	
	// Update is called once per frame
	void Update () {
		if(isCooling)
		{
			ClockTimer += Time.deltaTime;
		}
	}

	public IEnumerator UsePlayerSkill(float temp)
	{
		SetPosition();
		isCooling = true;
		ClockTimer = 0.0f;
		boxCollider2D.enabled = true;
		SkillEffect.SetActive(true);
		yield return new WaitForSeconds(temp);
		boxCollider2D.enabled = false;
		SkillEffect.SetActive(false);		
		PlayerManager.Interaction = false;
	}

	protected void SetPosition()
	{
		float vertical = anim.GetFloat("Vertical");
		float horizontal = anim.GetFloat("Horizontal");
		if(vertical == 0.0f && horizontal == 1.0f)
		{
			this.transform.localPosition = new Vector3(0.0f,5.0f,0.0f);
		}
		else if(vertical == 0.0f && horizontal == -1.0f)
		{
			this.transform.localPosition = new Vector3(0.0f,-5.0f,0.0f);			
		}
		else if(vertical == 1.0f && horizontal == 0.0f)
		{
			this.transform.localPosition = new Vector3(5.0f,0.0f,0.0f);
		}
		else if(vertical == -1.0f && horizontal == 0.0f)
		{
			this.transform.localPosition = new Vector3(-5.0f,0.0f,0.0f);
		}
	}
}
