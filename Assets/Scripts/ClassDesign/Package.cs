//Package class for storage
//By nature
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package{
	private int maxSpace;				//The max package space

	public List<Item> items;

	public int MaxSpace
	{
		get
		{
			return maxSpace;
		}
	}
	public int TakedSpace
	{
		get
		{
			int num = 0;
			foreach (Item tmp in items)
			{
				num += tmp.Take_place;
			}
			return num;
		}
	}
	
	public Package(int _place)
	{
		maxSpace = _place;
		items = new List<Item>();
	}

	public void AddItem(Item item)
	{
		if(IsPlaceEnough(item))
		{
			items.Add(item);
		}
		else
		{
			Debug.Log("Not Enough Space");
		}
	}
	
	public void RemoveItem(Item item)
	{
		items.Remove(item);
	}

	private bool IsPlaceEnough(Item item)
	{
		if((MaxSpace - TakedSpace)<item.Take_place)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public int GetItemsNum()
	{
		return items.Count;
	}
}
