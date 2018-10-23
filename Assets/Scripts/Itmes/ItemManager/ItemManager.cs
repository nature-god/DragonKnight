using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public StrongerItemManager strongerItemManager;
	public ResumeItemManager resumeItemManager;
	
	void Start()
	{
		if(this.GetComponent<StrongerItemManager>() == null)
		{
			resumeItemManager = this.GetComponent<ResumeItemManager>();
		}
		else if(this.GetComponent<ResumeItemManager>() == null)
		{
			strongerItemManager = this.GetComponent<StrongerItemManager>();
		}
		else
		{
			Debug.Log("Do not know the type of this Item!");
		}
	}

	public string Show()
	{
		string tmp = "";
		if(strongerItemManager == null)
		{
			tmp += ("物品名称: "+resumeItemManager.MedicalName+"\n")
				+  ("物品价格: "+resumeItemManager.MedicalPrice +"\n")
				+  ("物品描述: "+resumeItemManager.MedicalDescription);
		}
		else if(resumeItemManager == null)
		{
			tmp += ("物品名称: "+strongerItemManager.MedicalName+"\n")
			+  ("物品价格: "+strongerItemManager.MedicalPrice +"\n")
			+  ("物品描述: "+strongerItemManager.MedicalDescription);
		}
		else
		{
			Debug.Log("Do not know the type of this Item!");
		}
		return tmp;
	}

	public Item GetItem()
	{
		if(strongerItemManager == null)
		{
			return resumeItemManager.medicalItem;
		}
		else if(resumeItemManager == null)
		{
			return strongerItemManager.medicalItem;
		}
		else
		{
			return null;
		}
	}
}
