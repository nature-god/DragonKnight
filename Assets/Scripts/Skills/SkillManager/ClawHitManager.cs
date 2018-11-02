using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHitManager : SkillManager {

	public string ClawHitSkill_Name;
	public int Cooling_Time;
	public int SkillCost;
	public int Extra_Attack;
	public string Description;

	public ClawHit ClawHit_Skill;
	private Role User;
	
	// Use this for initialization
	void Start () {
		ClockCooling_Time = Cooling_Time;
		ClawHit_Skill = new ClawHit(ClawHitSkill_Name,Cooling_Time,SkillCost,Description,Extra_Attack);
		User = this.transform.parent.parent.GetComponent<MonsterManager>().Monster;
	}
	
	void OnTriggerEnter2D(Collider2D tmp)
	{
		if(tmp.gameObject.CompareTag("Player"))
		{
			ClawHit_Skill.SkillEffect(User,tmp.gameObject.transform.GetComponent<PlayerManager>().player);
		}
	}
}
