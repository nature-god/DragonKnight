﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEquipment : Equipment 
{	
	private int force_defense_strengthen;
	private int magic_defense_strengthen;

	public HeadEquipment(){}
	public HeadEquipment(string _name,int _price,string _description,int _take_place,
						int _force_defense_strengthen,int _magic_defense_strengthen):base(_name,_price,_description,_take_place)
	{
		force_defense_strengthen = _force_defense_strengthen;
		magic_defense_strengthen = _magic_defense_strengthen;
	}

	public override void UseItem(Role role)
	{
		if(((Player)role).Head.Name == "无")
		{
			((Player)role).Head = this;
			role.Force_defense += force_defense_strengthen;
			role.Magic_defense += magic_defense_strengthen;
		}
		else
		{
			((Player)role).Head.RemoveEquipment(role);
			((Player)role).Head = this;
			role.Force_defense += force_defense_strengthen;
			role.Magic_defense += magic_defense_strengthen;
		}

	}
	public override void RemoveEquipment(Role role)
	{
		role.Force_defense -= force_defense_strengthen;
		role.Magic_defense -= magic_defense_strengthen;
		((Player)role).PlayerPackage.AddItem(((Player)role).Head);
		((Player)role).Head = null;
	}
}
