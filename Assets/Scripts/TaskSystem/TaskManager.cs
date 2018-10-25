using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager{
	public List<Task> tasks;

	private static TaskManager instance;
	public static TaskManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new TaskManager();
			}
			return instance;
		}
	}

	TaskManager()
	{
		tasks = new List<Task>();
		Init();
	}

	void Init()
	{
		Task task01 = new Task("获取哥布林牙齿01",
								"Adventure_Servicer",
								"哥布林的牙齿是很好的武器原材料，雇主需要40枚哥布林牙齿,报酬50G");
		task01.CompleteTask = CompleteTask1;
		task01.Reward = RewardTask1;
		Task task02 = new Task("获取哥布林牙齿02",
								"Adventure_Servicer",
								"哥布林的牙齿是很好的武器原材料，雇主需要40枚哥布林牙齿,报酬50G");
		task02.CompleteTask = CompleteTask1;
		task02.Reward = RewardTask1;
		Task task03 = new Task("获取哥布林牙齿03",
								"Adventure_Servicer",
								"哥布林的牙齿是很好的武器原材料，雇主需要40枚哥布林牙齿,报酬50G");
		task03.CompleteTask = CompleteTask1;
		task03.Reward = RewardTask1;
		Task task04 = new Task("获取哥布林牙齿04",
								"Adventure_Servicer",
								"哥布林的牙齿是很好的武器原材料，雇主需要40枚哥布林牙齿,报酬50G");
		task04.CompleteTask = CompleteTask1;
		task04.Reward = RewardTask1;
		Task task05 = new Task("获取哥布林牙齿05",
								"Adventure_Servicer",
								"哥布林的牙齿是很好的武器原材料，雇主需要40枚哥布林牙齿,报酬50G");
		task05.CompleteTask = CompleteTask1;
		task05.Reward = RewardTask1;

		tasks.Add(task01);
		tasks.Add(task02);
		tasks.Add(task03);
		tasks.Add(task04);
		tasks.Add(task05);

	}

	public bool CompleteTask1()
	{
		if(Completetask_WithItem("Golblin_Teeth",5))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public void RewardTask1()
	{
		Reward_Gold(80,"Golblin_Teeth,",5);
	}

	public void Reward_Gold(int reward_Gold,string item_name,int num)
	{
		for(int i = 0;i<num;i++)
		{
			GameManager.Instance.player.PlayerPackage.RemoveItem(item_name);
		}
		GameManager.Instance.player.Gold += reward_Gold;
	}
	public void Reward_Item(Item reward_Item)
	{
		GameManager.Instance.player.PlayerPackage.AddItem(reward_Item);
	}

	public bool Completetask_WithItem(string item_name,int num)
	{
		if(GameManager.Instance.player.PlayerPackage.GetSameItemsNum(item_name) >= num)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
