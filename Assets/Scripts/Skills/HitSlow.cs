using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSlow : SpecialMagicSkill {

	private int slow_num;
	private int duration;
	public HitSlow(string _name,int _cooling_time,int _cost,int _slow_num,int _duration,string _description)
	 : base(_name,_cooling_time,_cost,_description)
	{
		slow_num = _slow_num;
		duration = _duration;
	}

	public override void SkillEffect(Role user,Role customer)
	{
		//The magic is enough
		if(SpecialMagicHelper(user))
		{
			//The magic hit the customer
			if(SpecialMagicHitHelper(user,customer))
			{
				SlowStatus bloodDropping = new SlowStatus(slow_num,duration);
				GameObject.Find("RoleStatusManager").GetComponent<RoleInGameStatusManager>().StartCoroutine(bloodDropping.StartStatus(customer));
			}
		}
	}
}
