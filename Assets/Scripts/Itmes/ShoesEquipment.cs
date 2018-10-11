using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesEquipment : Equipment {
	private int move_speed_strengthen;
	private int dodge_strengthen;

	public ShoesEquipment(){}
	public ShoesEquipment(string _name,int _price,string _description,int _take_place,
						int _move_speed_strengthen,int _dodge_strengthen):base(_name,_price,_description,_take_place)
	{
		move_speed_strengthen = _move_speed_strengthen;
		dodge_strengthen = _dodge_strengthen;
	}

	public override void UseItem(Role role)
	{
		((Player)role).Shoes = this;
		role.Move_speed += move_speed_strengthen;
		role.Dodge += dodge_strengthen;
	}
	public override void RemoveEquipment(Role role)
	{
		((Player)role).Shoes = null;
		role.Move_speed -= move_speed_strengthen;
		role.Dodge -= dodge_strengthen;
	}
}
