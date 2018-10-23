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

		//FastHealthResumeMedical tmp1 = new FastHealthResumeMedical("测试丹1",50,"测试用丹药",1,10);
		//FastHealthResumeMedical tmp2 = new FastHealthResumeMedical("测试丹2",50,"测试用丹药",1,10);
		//FastHealthResumeMedical tmp3 = new FastHealthResumeMedical("测试丹3",50,"测试用丹药",1,10);
		//FastHealthResumeMedical tmp4 = new FastHealthResumeMedical("测试丹4",50,"测试用丹药",1,10);
		//FastHealthResumeMedical tmp5 = new FastHealthResumeMedical("测试丹5",50,"测试用丹药",1,10);
		//FastHealthResumeMedical tmp6 = new FastHealthResumeMedical("测试丹6",50,"测试用丹药",1,10);
		//FastHealthResumeMedical tmp7 = new FastHealthResumeMedical("测试丹7",50,"测试用丹药",1,10);
		//FastHealthResumeMedical tmp8 = new FastHealthResumeMedical("测试丹8",50,"测试用丹药",1,10);
		//FastHealthResumeMedical tmp9 = new FastHealthResumeMedical("测试丹9",50,"测试用丹药",1,10);

		//AddItem(tmp1);
		//AddItem(tmp2);
		//AddItem(tmp3);
		//AddItem(tmp4);
		//AddItem(tmp5);
		//AddItem(tmp6);
		//AddItem(tmp7);
		//AddItem(tmp8);
		//AddItem(tmp9);



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

	public bool IsPlaceEnough(Item item)
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
