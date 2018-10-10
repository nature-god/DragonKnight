using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHit : ForceSkill {
	public ClawHit(string _name,int _cooling_time,int _cost,string _description,int _extra_attack) : base(_name,_cooling_time,_cost,_description,_extra_attack)
	{

	}
	public override void SkillEffect(Role user,Role customer)
	{
		ForceAttackHelper(user,customer);
	}

}
