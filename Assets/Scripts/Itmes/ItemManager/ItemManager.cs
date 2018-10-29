using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public enum ItemManagerType
	{
		strongerItemManager = 0,
		resumeItemManager = 1,
		equipmentManager = 2
	};
	public ItemManagerType itemManagerType;

	public StrongerItemManager strongerItemManager;
	public ResumeItemManager resumeItemManager;
	public EquipmentManager equipmentManager;

	void Start()
	{
		switch (itemManagerType)
		{
			case ItemManagerType.strongerItemManager:
			{
				strongerItemManager = this.GetComponent<StrongerItemManager>();
				break;
			}	
			case ItemManagerType.resumeItemManager:
			{
				resumeItemManager = this.GetComponent<ResumeItemManager>();
				break;
			}
			case ItemManagerType.equipmentManager:
			{
				equipmentManager = this.GetComponent<EquipmentManager>();
				break;
			}
			default:
			{
				Debug.Log("Do not know the type of this Item!");
				break;
			}
		}
	}

	public string Show()
	{
		string tmp = "";
		switch(itemManagerType)
		{
			case ItemManagerType.strongerItemManager:
			{
				tmp += ("物品名称: "+strongerItemManager.MedicalName+"\n")
					+  ("物品价格: "+strongerItemManager.MedicalPrice +"\n")
					+  ("物品描述: "+strongerItemManager.MedicalDescription);
				break;
			}
			case ItemManagerType.resumeItemManager:
			{
				tmp += ("物品名称: "+resumeItemManager.MedicalName+"\n")
					+  ("物品价格: "+resumeItemManager.MedicalPrice +"\n")
					+  ("物品描述: "+resumeItemManager.MedicalDescription);
				break;
			}
			case ItemManagerType.equipmentManager:
			{
				tmp += ("物品名称: "+equipmentManager.ItemName+"\n")
					+  ("物品价格: "+equipmentManager.ItemPrice +"\n")
					+  ("物品描述: "+equipmentManager.ItemDescription);
				break;
			}
			default:
			{
				Debug.Log("Do not know the type of this Item!");
				break;
			}
		}
		return tmp;
	}

	public Item GetItem()
	{
		switch(itemManagerType)
		{
			case ItemManagerType.strongerItemManager:
			{
				return strongerItemManager.medicalItem;
			}
			case ItemManagerType.resumeItemManager:
			{
				return resumeItemManager.medicalItem;
			}
			case ItemManagerType.equipmentManager:
			{
				return equipmentManager.EquipmentItem;
			}
			default:
			{
				return null;
			}
		}
	}
}
