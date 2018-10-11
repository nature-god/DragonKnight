using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHitStrongerMedical : Item {
	private int stronger_num;
	private int continus_time;

	public MagicHitStrongerMedical(string _name,int _price,string _description,int _take_place,int _stronger_num,int _continus_time)
	: base(_name,_price,_description,_take_place)
	{
		stronger_num = _stronger_num;
		continus_time = _continus_time;
	}

	public override void UseItem(Role user)
	{
		MagicHitStrongerStatus tmp = new MagicHitStrongerStatus(stronger_num,continus_time);
		StartCoroutine(tmp.StartStatus(user));
	}
}
