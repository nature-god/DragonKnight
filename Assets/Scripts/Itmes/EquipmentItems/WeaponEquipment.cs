using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipment : Equipment {
	private int force_attack_strengthen;	
	private int magic_attack_strengthen;

	public WeaponEquipment(){}
	public WeaponEquipment(string _name,int _price,string _description,int _take_place,
						int _force_attack_strengthen,int _magic_attack_strengthen):base(_name,_price,_description,_take_place)
	{
		force_attack_strengthen = _force_attack_strengthen;
		magic_attack_strengthen = _magic_attack_strengthen;
	}

	public override void UseItem(Role role)
	{
		if(((Player)role).Weapon.Name == "无")
		{
			((Player)role).Weapon = this;
			role.Force_attack += force_attack_strengthen;
			role.Magic_attack += magic_attack_strengthen;
		}
		else
		{
			((Player)role).Weapon.RemoveEquipment(role);
			((Player)role).Weapon = this;
			role.Force_attack += force_attack_strengthen;
			role.Magic_attack += magic_attack_strengthen;
		}
	}
	public override void RemoveEquipment(Role role)
	{
		role.Force_attack -= force_attack_strengthen;
		role.Magic_attack -= magic_attack_strengthen;
		((Player)role).PlayerPackage.AddItem(((Player)role).Weapon);
		((Player)role).Weapon = null;
	}
}
