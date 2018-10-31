using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeManager : MonoBehaviour {

	public MonsterManager monsterManager;
	void Start()
	{
		monsterManager = this.transform.parent.transform.GetComponent<MonsterManager>();
	}
	void OnTriggerEnter2D(Collider2D tmp)
	{
		if(tmp.gameObject.CompareTag("Player"))
		{
			monsterManager._MonsterStatus = MonsterManager.MonsterStatus.Attack;
		}
	}
}
