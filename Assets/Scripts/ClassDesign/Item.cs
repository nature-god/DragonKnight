//The Item class for items
//By nature
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item {
	private string item_name;		//The Item name
	private int price;		//The price of the Item, 50% off for sale
	private string description;	//The description of the item
	private int take_place;		//How many the item would take the place of packages
	#region  attributes accessor
	public string Name
	{
		get
		{
			return item_name;
		}
	}
	public int Price
	{
		get
		{
			return price;
		}
	}
	public string Description
	{
		get
		{
			return description;
		}
	}
	public int Take_place
	{
		get
		{
			return take_place;
		}
	}
	#endregion

	public Item(){}

	///<summary>Constructor</summary>
	///<param name="_item_name">The Item name</param>
	///<param name="_price">The price of the Item, 50% off for sale</param>
	///<param name="_description">The description of the item</param>
	///<param name="_take_place">How many the item would take the place of packages	</param>
	public Item(string _name,int _price,string _description,int _take_place)
	{
		item_name = _name;
		price = _price;
		description = _description;
		take_place = _take_place;
	}

	public virtual void UseItem(Role user){}
	public string ItemMessage()
	{
		string tmp = "物品名称: "+item_name+"\n";
		tmp += "描述信息: "+description;
		return tmp;
	}
}

public abstract class Equipment	: Item
{
	public Equipment(){}
	public Equipment(string _name,int _price,string _description,int _take_place):base(_name,_price,_description,_take_place)
	{

	}
	public virtual void RemoveEquipment(Role user)
	{

	}
}

