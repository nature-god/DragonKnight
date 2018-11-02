using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemManager : MonoBehaviour {

	public Item item;

	void OnTriggerEnter2D(Collider2D tmp)
	{
		if(tmp.gameObject.CompareTag("Player"))
		{
			tmp.GetComponent<PlayerManager>().player.PlayerPackage.AddItem(item);
			GameObject.Destroy(this.gameObject);
		}
	}
}
