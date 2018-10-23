using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMagicResumeMedical : Item {
	private int resume_num;

	public FastMagicResumeMedical(string _name,int _price,string _description,int _take_place,int _resume_num)
	: base(_name,_price,_description,_take_place)
	{
		resume_num = _resume_num;
	}

	public override void UseItem(Role user)
	{
		user.Current_magic += resume_num;
	}
}
