using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDizzy : SpecialMagicSkill {

	private int duration;
	public HitDizzy(string _name,int _cooling_time,int _cost,int _duration,string _description)
	 : base(_name,_cooling_time,_cost,_description)
	{
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
				DizzyStatus bloodDropping = new DizzyStatus(duration);
				StartCoroutine(bloodDropping.StartStatus(customer));
			}
		}
	}
}
