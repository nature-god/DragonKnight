using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task{
	private string task_name;				//The Name of Task
	private string object_NPC_name;			//The Task NPC Name
	private string description;				//The Description of the task
	private bool completed;					//Whether the task is completed
	
	#region accessors
	public bool Completed
	{
		set 
		{
			completed = value;
		}
		get
		{
			return completed;
		}
	}

	public string Task_name
	{
		get
		{
			return task_name;
		}
	}
	public string Object_NPC_name
	{
		get
		{
			return object_NPC_name;
		}
	}
	public string Description
	{
		get
		{
			return description;
		}
	}
	#endregion

	#region Constructors
	public Task(){}
	public Task(string _task_name,string _object_NPC_name,string _description)
	{
		task_name = _task_name;
		object_NPC_name = _object_NPC_name;
		description = _description;
		completed = false;
	}
	#endregion
}

public class Reward
{
	private int reward_gold;
	private List<Item> reward_items;
	public int Reward_gold
	{
		get
		{
			return reward_gold;
		}
	}
	public List<Item> Reward_items
	{
		get
		{
			return reward_items;
		}
	}

	public Reward(int _reward_gold,List<Item> _reward_items)
	{
		reward_gold = _reward_gold;
		reward_items = _reward_items;
	}
}

public class SmallTask_FindNPCToTalk : Task,ITask
{
	public SmallTask_FindNPCToTalk(){}

	public SmallTask_FindNPCToTalk(string _task_name,string _object_NPC_name,string _description)
	:base(_task_name,_object_NPC_name,_description)
	{

	}

	public void CompleteTask(Player tasker,Reward reward)
	{
		Completed = true;
		tasker.Gold += reward.Reward_gold;
		foreach (Item item in reward.Reward_items)
		{
			tasker.PlayerPackage.AddItem(item);			
		}
		//How to handle the situation that the package place is not enough?
	}
}

public class SmallTask_GetItemsToNPC : Task,ITask
{
	private string object_item_name;
	private int object_item_num;
	public string Object_item_name
	{
		get
		{
			return object_item_name;
		}
	}
	public int Object_item_num 
	{
		get
		{
			return object_item_num;
		}
	}

	public SmallTask_GetItemsToNPC(){}

	public SmallTask_GetItemsToNPC(string _task_name,string _object_NPC_name,string _description,string _object_item_name,int _object_item_num)
	:base(_task_name,_object_NPC_name,_description)
	{
		object_item_name = _object_item_name;
		object_item_num = _object_item_num;
	}


	public void CompleteTask(Player tasker,Reward reward)
	{
		Completed = true;
		tasker.Gold += reward.Reward_gold;
		foreach (Item item in reward.Reward_items)
		{
			tasker.PlayerPackage.AddItem(item);			
		}
		//How to handle the situation that the package place is not enough?
	}
}
