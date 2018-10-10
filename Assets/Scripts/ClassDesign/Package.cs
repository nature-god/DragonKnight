//Package class for storage
//By nature
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package{
	private int place;				//The package Places
	public List<Item> items;
	
	public Package(int _place)
	{
		place = _place;
	}

	private bool IsPlaceEnough(Item item)
	{
		int num = 0;
		foreach (Item tmp in items)
		{
			num += tmp.Take_place;
		}
		if(( place - num ) < item.Take_place)
		{
			return false;
		}
		else
		{
			return true;
		}
	}
}
