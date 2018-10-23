using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
	public Player player;
	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameManager();
			}
			return instance;
		}
	}

	private GameManager()
	{
		LoadPlayer();
	}

	private	void LoadPlayer()
	{
		player = new Player("nature",0,"Human",1,
							10,10,10,1,0,
							15,5,5,1,0,
							100,20,5,5,100,20,
							100,100,0,20000);
	}

	public static void Show()
	{
		Debug.Log("====>Load Player<====");
		GameManager.Instance.player.Show();
	}
}
