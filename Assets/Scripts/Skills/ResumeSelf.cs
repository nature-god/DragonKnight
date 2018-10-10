using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeSelf : SpecialMagicSkill {

	private int resume_num;

	public ResumeSelf(string _name,int _cooling_time,int _cost,int _resume_num,string _description) : base(_name,_cooling_time,_cost,_description)
	{	
		resume_num = _resume_num;
	}
	public override void SkillEffect(Role user,Role customer)
	{
		SpecialMagicHelper(user);
		customer.Current_health += resume_num;
	}
}
