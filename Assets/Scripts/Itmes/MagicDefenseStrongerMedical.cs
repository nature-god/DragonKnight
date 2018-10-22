using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDefenseStrongerMedical : Item {
	private int stronger_num;
	private int continus_time;

	public MagicDefenseStrongerMedical(string _name,int _price,string _description,int _take_place,int _stronger_num,int _continus_time)
	: base(_name,_price,_description,_take_place)
	{
		stronger_num = _stronger_num;
		continus_time = _continus_time;
	}

	public override void UseItem(Role user)
	{
		MagicDefenseStrongerStatus tmp = new MagicDefenseStrongerStatus(stronger_num,continus_time);
		GameObject.Find("RoleStatusManager").GetComponent<RoleInGameStatusManager>().StartCoroutine(tmp.StartStatus(user));
	}
}
