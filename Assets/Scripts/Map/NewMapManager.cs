using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapManager : MonoBehaviour {

	public int horizontal_num;
	public int vertical_num;
	public Transform Map;
	public GameObject ImagePrefab;

	public void CreateImagePrefab()
	{
		for(int i = 0;i<horizontal_num;i++)
		{
			for(int j=0;j<vertical_num;j++)
			{
				Instantiate(ImagePrefab,Map).transform.GetComponent<RectTransform>().localPosition = new Vector3(5*i,5*j,0);
			}
		}
		Debug.Log("CreateImage!");
	}
}
