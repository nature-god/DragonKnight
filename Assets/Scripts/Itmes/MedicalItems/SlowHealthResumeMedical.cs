using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowHealthResumeMedical : Item {
	private int resume_num;

	public SlowHealthResumeMedical(string _name,int _price,string _description,int _take_place,int _resume_num)
	: base(_name,_price,_description,_take_place)
	{
		resume_num = _resume_num;
	}

	public override void UseItem(Role user)
	{
		BloodAddingStatus bloodAdding = new BloodAddingStatus(resume_num/10,10);
		GameObject.Find("RoleStatusManager").GetComponent<RoleInGameStatusManager>().StartCoroutine(bloodAdding.StartStatus(user));
	}
}
