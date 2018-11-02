using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItemManager : MonoBehaviour {

	public string Item_Name;
	public int Price;
	public int Take_place;
	public string Description;

	public NormalItem normalItem;
	// Use this for initialization
	void Start () {
		normalItem = new NormalItem(Item_Name,Price,Description,Take_place);
	}
}
