using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task{
	private string task_name;				//The Name of Task
	private string object_NPC_name;			//The Task NPC Name
	private string description;				//The Description of the task
	private bool completed;					//Whether the task is completed
	private Task next_task;					//The Next task
	
	#region accessors
	public Task Next_task					
	{
		get
		{
			return next_task;
		}
	}
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
		next_task = new Task();
		completed = false;
	}
	#endregion

	public void SetNextTask(Task _next_task)
	{
		next_task = _next_task;
	}
}

public class SmallTask_FindNPCToTalk : Task,ITask
{
	public SmallTask_FindNPCToTalk(){}

	public SmallTask_FindNPCToTalk(string _task_name,string _object_NPC_name,string _description)
	:base(_task_name,_object_NPC_name,_description)
	{

	}

	public void CompleteTask()
	{
		Completed = true;
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


	public void CompleteTask()
	{
		Completed = true;
	}
}
