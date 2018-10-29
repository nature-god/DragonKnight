using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemManager))]
public class ItemManagerEditor : Editor {
	private SerializedObject itemManager;

	private SerializedProperty itemManagerType;
	private SerializedProperty strongItemManager;
	private SerializedProperty resumeItemManager;
	private SerializedProperty equipmentManager;

	void OnEnable()
	{
		itemManager = new SerializedObject(target);

		itemManagerType = itemManager.FindProperty("itemManagerType");
		strongItemManager = itemManager.FindProperty("strongerItemManager");
		resumeItemManager = itemManager.FindProperty("resumeItemManager");
		equipmentManager = itemManager.FindProperty("equipmentManager");
	}

	public override void OnInspectorGUI()
	{
		itemManager.Update();
		EditorGUILayout.PropertyField(itemManagerType);
		switch (itemManagerType.enumValueIndex)
		{
			case 0:
			{
				EditorGUILayout.PropertyField(strongItemManager);
				break;
			}
			case 1:
			{
				EditorGUILayout.PropertyField(resumeItemManager);
				break;
			}
			case 2:
			{
				EditorGUILayout.PropertyField(equipmentManager);
				break;
			}
			default:
			{
				Debug.Log("Error Type");
				break;
			}
		}
		itemManager.ApplyModifiedProperties();
	}
}
