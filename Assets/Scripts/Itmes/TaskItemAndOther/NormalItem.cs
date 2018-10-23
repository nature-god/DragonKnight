using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item {

	public NormalItem(string _name,int _price,string _description,int _take_place)
	: base(_name,_price,_description,_take_place)
	{

	}

	public override void UseItem(Role user)
	{
		Debug.Log("This is" + Name + " " + Description + "can be sold to earn some money.");
	}
}
