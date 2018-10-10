using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLosingBlood : SpecialMagicSkill {

	private int losingNumPerTime;
	private int duration;


	public HitLosingBlood(string _name,int _cooling_time,int _cost,int _losingNumPerTime,int _duration,string _description)
	 : base(_name,_cooling_time,_cost,_description)
	{
		losingNumPerTime = _losingNumPerTime;
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
				BloodDroppingStatus bloodDropping = new BloodDroppingStatus(losingNumPerTime,duration);
				StartCoroutine(bloodDropping.StartStatus(customer));
			}
		}
	}
}
