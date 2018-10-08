//The Item class for items
//By nature
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item{
	private string name;		//The Item name
	private string price;		//The price of the Item, 50% off for sale
	private string description;	//The description of the item
	private int take_place;		//How many the item would take the place of packages
	#region  attributes accessor
	public string Name
	{
		get
		{
			return name;
		}
	}
	public string Price
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
	///<summary>Constructor</summary>
	///<param name="_name">The Item name</param>
	///<param name="_price">The price of the Item, 50% off for sale</param>
	///<param name="_description">The description of the item</param>
	///<param name="_take_place">How many the item would take the place of packages	</param>
	public Item(string _name,string _price,string _description,int _take_place)
	{
		name = _name;
		price = _price;
		description = _description;
		take_place = _take_place;
	}

	public virtual void UseItem(Role user){}
}
