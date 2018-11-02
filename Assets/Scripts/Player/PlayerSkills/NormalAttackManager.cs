using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalAttackManager : SkillIconManager {

	// Use this for initialization
	void Start() {
		skill = new ClawHit("木棒打击",2,0,"木棒打击！",10);
		UseSkill = UseOneSkill;
		CoolingTime = skill.Cooling_time;
		isCooling = false;
		anim = this.transform.parent.parent.transform.GetChild(1).GetComponent<Animator>();
		boxCollider2D = this.transform.GetComponent<BoxCollider2D>();
		boxCollider2D.enabled = false;
	}
	
	void UseOneSkill()
	{
		SetPosition();
		StartCoroutine(UsePlayerSkill(0.5f));
	}

	void OnTriggerEnter2D(Collider2D tmp)
	{
		if(tmp.gameObject.CompareTag("Monster"))
		{
			skill.SkillEffect(GameManager.Instance.player,tmp.gameObject.transform.parent.GetComponent<MonsterManager>().Monster);
		}
	}
}
