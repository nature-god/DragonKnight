using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task{
	private string task_name;				//The Name of Task
	private string object_NPC_name;			//The Task NPC Name
	private string description;				//The Description of the task
	
	public delegate bool CompleteTaskDelegate();
	public delegate void RewardDelegate();

	public CompleteTaskDelegate CompleteTask;
	public RewardDelegate Reward; 
	
	#region accessors
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
	}
	#endregion
}