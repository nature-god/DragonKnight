using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EquipmentManager))]
public class EquipmentManagerEditor : Editor {
	//Serialize the object
	private SerializedObject equipmentManager;
	//Serialize the properties
	private SerializedProperty equipmentType;
	private SerializedProperty equipment_name;
	private SerializedProperty equipment_price;
	private SerializedProperty equipment_description;
	private SerializedProperty equipment_take_place;
	private SerializedProperty force_defense_strengthen;
	private SerializedProperty force_attack_strengthen;
	private SerializedProperty force_hit_strengthen;
	private SerializedProperty magic_defense_strengthen;
	private SerializedProperty magic_attack_strengthen;
	private SerializedProperty magic_hit_strengthen;
	private SerializedProperty move_speed_strengthen;
	private SerializedProperty dodge_strengthen;

	void OnEnable()
	{
		equipmentManager = new SerializedObject(target);

		equipmentType = equipmentManager.FindProperty("ItemType");

		equipment_name = equipmentManager.FindProperty("ItemName");
		equipment_price = equipmentManager.FindProperty("ItemPrice");
		equipment_take_place = equipmentManager.FindProperty("ItemTakePlace");
		equipment_description = equipmentManager.FindProperty("ItemDescription");

		force_defense_strengthen = equipmentManager.FindProperty("Force_defense_strengthen");
		force_attack_strengthen = equipmentManager.FindProperty("Force_attack_strengthen");
		force_hit_strengthen = equipmentManager.FindProperty("Force_hit_strengthen");

		magic_defense_strengthen = equipmentManager.FindProperty("Magic_attack_strengthen");
		magic_attack_strengthen = equipmentManager.FindProperty("Magic_defense_strengthen");
		magic_hit_strengthen = equipmentManager.FindProperty("Magic_hit_strengthen");

		move_speed_strengthen = equipmentManager.FindProperty("Move_speed_strengthen");
		dodge_strengthen = equipmentManager.FindProperty("Dodge_strengthen");
	}

	public override void OnInspectorGUI()
	{
		equipmentManager.Update();
		EditorGUILayout.PropertyField(equipmentType);
		EditorGUILayout.PropertyField(equipment_name);
		EditorGUILayout.PropertyField(equipment_price);
		EditorGUILayout.PropertyField(equipment_take_place);
		//Debug.Log(equipmentType.enumValueIndex);
		switch(equipmentType.enumValueIndex)
		{
			case 0:
			{
				//HeadEquipment
				EditorGUILayout.PropertyField(force_defense_strengthen);
				EditorGUILayout.PropertyField(magic_defense_strengthen);
				break;
			}
			case 1:
			{
				//HandGuardEquipment
				EditorGUILayout.PropertyField(force_hit_strengthen);
				EditorGUILayout.PropertyField(magic_hit_strengthen);
				break;
			}
			case 2:
			{
				//ClothEquipment
				EditorGUILayout.PropertyField(force_defense_strengthen);
				EditorGUILayout.PropertyField(magic_defense_strengthen);
				break;
			}
			case 3:
			{
				//WeaponEquipment
				EditorGUILayout.PropertyField(force_attack_strengthen);
				EditorGUILayout.PropertyField(magic_attack_strengthen);
				break;
			}
			case 4:
			{
				//ShoesEquipment
				EditorGUILayout.PropertyField(dodge_strengthen);
				EditorGUILayout.PropertyField(move_speed_strengthen);
				break;
			}
		}
		EditorGUILayout.PropertyField(equipment_description);
		equipmentManager.ApplyModifiedProperties();
	}
}
