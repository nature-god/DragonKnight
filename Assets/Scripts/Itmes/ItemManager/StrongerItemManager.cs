using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerItemManager : MonoBehaviour {

	public enum StrongerItemType
	{
		ForceAttackStronger=0,
		ForceDefenseStronger=1,
		ForceHitStronger=2,
		MagicAttackStronger=3,
		MagicDefenseStronger=4,
		MagicHitStronger=5
	};

	public StrongerItemType ItemType;

	public Item medicalItem;
	// /string _name,int _price,string _description,int _take_place,int _stronger_num,int _continus_time
	public string MedicalName;
	public int MedicalPrice;
	public int MedicalSpcaeTake;
	public int MedicalStrongerNum;
	public int MedicalContinusTime;
	public string MedicalDescription;


	// Use this for initialization
	void Start () {
		switch (ItemType)
		{
			case StrongerItemType.ForceAttackStronger:
				medicalItem = new ForceAttackStrongerMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalStrongerNum,MedicalContinusTime);
				break;
			case StrongerItemType.ForceDefenseStronger:
				medicalItem = new ForceDefenseStrongerMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalStrongerNum,MedicalContinusTime);
				break;
			case StrongerItemType.ForceHitStronger:
				medicalItem = new ForceHitStrongerMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalStrongerNum,MedicalContinusTime);
				break;
			case StrongerItemType.MagicAttackStronger:
				medicalItem = new MagicAttackStrongerMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalStrongerNum,MedicalContinusTime);
				break;
			case StrongerItemType.MagicDefenseStronger:
				medicalItem = new MagicDefenseStrongerMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalStrongerNum,MedicalContinusTime);
				break;
			case StrongerItemType.MagicHitStronger:
				medicalItem = new MagicHitStrongerMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalStrongerNum,MedicalContinusTime);
				break;				
			default:
				break;
		}
	}
}
