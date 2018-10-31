using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NewMapManager))]
public class MapEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		NewMapManager myScript = (NewMapManager)target;
		if(GUILayout.Button("Build Object"))
		{
			myScript.CreateImagePrefab();
		}
	}
}
