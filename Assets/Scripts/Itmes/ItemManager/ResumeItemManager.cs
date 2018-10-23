using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeItemManager : MonoBehaviour {
	//string _name,int _price,string _description,int _take_place,int _resume_num
	public StrongerItemType ItemType;

	public string MedicalName;
	public int MedicalPrice;
	public int MedicalSpcaeTake;
	public int MedicalResumeNum;
	public string MedicalDescription;

	public enum StrongerItemType
	{
		FastHealthResumeMedical=0,
		FastMagicResumeMedical=1,
		SlowHealthResumeMedical=2,
		SlowMagicResumeMedical=3
	}


	public Item medicalItem;
	// Use this for initialization
	void Start () {
		switch (ItemType)
		{
			case StrongerItemType.FastHealthResumeMedical:
				medicalItem = new FastHealthResumeMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalResumeNum);
				break;
			case StrongerItemType.FastMagicResumeMedical:
				medicalItem = new FastMagicResumeMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalResumeNum);
				break;
			case StrongerItemType.SlowHealthResumeMedical:
				medicalItem = new SlowHealthResumeMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalResumeNum);
				break;
			case StrongerItemType.SlowMagicResumeMedical:
				medicalItem = new SlowMagicResumeMedical(MedicalName,MedicalPrice,MedicalDescription,MedicalSpcaeTake,MedicalResumeNum);
				break;			
			default:
				break;
		}
	}

}
