using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	public enum EquipmentType
	{
		HeadEquipment = 0,
		HandGuardEquipment = 1,
		ClothEquipment = 2,
		WeaponEquipment = 3,
		ShoesEquipment = 4
	};
	public EquipmentType ItemType;
	public string ItemName;
	public int ItemPrice;
	public int ItemTakePlace;

	public int Force_attack_strengthen;
	public int Force_defense_strengthen;
	public int Force_hit_strengthen;
	public int Magic_attack_strengthen;
	public int Magic_defense_strengthen;
	public int Magic_hit_strengthen;
	public int Move_speed_strengthen;
	public int Dodge_strengthen;

	public string ItemDescription;

	public Item EquipmentItem;
	// Use this for initialization
	void Start () {
		switch(ItemType)
		{
			case EquipmentType.HeadEquipment:
			{
				EquipmentItem = new HeadEquipment(ItemName,ItemPrice,ItemDescription,ItemTakePlace,Force_defense_strengthen,Magic_defense_strengthen);
				break;
			}
			case EquipmentType.HandGuardEquipment:
			{
				EquipmentItem = new HandGuardEquipment(ItemName,ItemPrice,ItemDescription,ItemTakePlace,Force_hit_strengthen,Magic_hit_strengthen);
				break;
			}
			case EquipmentType.ClothEquipment:
			{
				EquipmentItem = new ClothEquipment(ItemName,ItemPrice,ItemDescription,ItemTakePlace,Force_defense_strengthen,Magic_defense_strengthen);
				break;
			}
			case EquipmentType.WeaponEquipment:
			{
				EquipmentItem = new WeaponEquipment(ItemName,ItemPrice,ItemDescription,ItemTakePlace,Force_attack_strengthen,Magic_attack_strengthen);
				break;
			}
			case EquipmentType.ShoesEquipment:
			{
				EquipmentItem = new ShoesEquipment(ItemName,ItemPrice,ItemDescription,ItemTakePlace,Move_speed_strengthen,Dodge_strengthen);
				break;
			}
			default:
			{
				Debug.Log("Error Equipment Type");
				break;
			}
		}	
	}
}
