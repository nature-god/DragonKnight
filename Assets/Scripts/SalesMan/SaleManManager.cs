using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleManManager : MonoBehaviour {

	public string WelcomeTalk;
	public GameObject[] SaleThings;
	// Use this for initialization
	void Start () {
		int childCount = this.transform.GetChild(0).childCount;
		SaleThings = new GameObject[childCount];
		for(int i=0;i<childCount;i++)
		{
			this.transform.GetChild(0).GetChild(i).GetComponent<Image>().enabled = false;
			SaleThings[i] = this.transform.GetChild(0).GetChild(i).gameObject;
		}
	}

	void OnCollisionEnter2D(Collision2D tmp)
	{
		if(tmp.gameObject.CompareTag("Player"))
		{
			SaleManCanvasManager.SaleMan = this.GetComponent<SaleManManager>();
			GameObject.Find("World").transform.Find("SaleManCanvas").gameObject.SetActive(true);
			PlayerManager.Interaction = true;
		}
	}
}
