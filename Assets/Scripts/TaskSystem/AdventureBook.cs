using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureBook{

	private static AdventureBook instance;
	public static AdventureBook Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new AdventureBook();
			}
			return instance;
		}
	}

	private Dictionary<string,int> AdventureLog;
	
	AdventureBook()
	{
		AdventureLog = new Dictionary<string,int>();
		Init();
	}
	
	public void AddRecord(string name,int num)
	{
		AdventureLog[name] = num+GetNumWithKey(name);
	}
	public int GetNumWithKey(string keyName)
	{
		int tmp = 0;
		foreach (string key in AdventureLog.Keys)
		{
			if(key == keyName)
			{
				tmp = AdventureLog[key];
				break;
			}
		}
		return tmp;
	}

	private void Init()
	{
		AdventureLog["IsAdventurer"] = 0;
		AdventureLog["Rookie_Level"] = 100;
		AdventureLog["Adventurer_Level"] = 100;
		AdventureLog["Master_Level"] = 100;
		AdventureLog["Legend_Level"] = 100;
		AdventureLog["HolyField_Level"] = 100;
		AdventureLog["Star_Level"] = 100;

		GameManager.Instance.player.Reputation = 40000;
	}
}
