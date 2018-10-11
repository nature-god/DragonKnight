using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

	public List<Task> tasks;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D (Collision2D tmp) 
	{
		foreach (Task task in tasks)
		{
			if(tmp.gameObject.transform.name == task.Object_NPC_name)
			{
				if(task.Completed)
				{
					//Completed the
				}
			}
		}	
	}
}
