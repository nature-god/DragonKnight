using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGuardEquipment : Equipment {
	private int force_hit_strengthen;	
	private int magic_hit_strengthen;

	public HandGuardEquipment(){}
	public HandGuardEquipment(string _name,int _price,string _description,int _take_place,
						int _force_hit_strengthen,int _magic_hit_strengthen):base(_name,_price,_description,_take_place)
	{
		force_hit_strengthen = _force_hit_strengthen;
		magic_hit_strengthen = _magic_hit_strengthen;
	}

	public override void UseItem(Role role)
	{
		if(((Player)role).HandGuard.Name == "无")
		{
			((Player)role).HandGuard = this;
			role.Force_hit += force_hit_strengthen;
			role.Magic_hit += magic_hit_strengthen;
		}
		else
		{
			((Player)role).HandGuard.RemoveEquipment(role);
			((Player)role).HandGuard = this;
			role.Force_hit += force_hit_strengthen;
			role.Magic_hit += magic_hit_strengthen;
		}

	}
	public override void RemoveEquipment(Role role)
	{
		role.Force_hit -= force_hit_strengthen;
		role.Magic_hit -= magic_hit_strengthen;
		((Player)role).PlayerPackage.AddItem(((Player)role).HandGuard);
		((Player)role).HandGuard = null;
	}
}
