using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialNPCTalkManager : MonoBehaviour {

	public string[] Selections;
	public string roleLines;

	///<suammry>Choose which Options</summary>
	///<param name = option>Whick Option</param>
	public virtual void Choose(int option){}

	void OnCollisionEnter2D (Collision2D tmp) 
	{
		if(tmp.gameObject.CompareTag("Player"))
		{
			ChooseCanvasManager.DefaultLines = roleLines;
			GameObject.Find("World").transform.Find("ChooseCanvas").transform.GetComponent<ChooseCanvasManager>().Selections = Selections;
			GameObject.Find("World").transform.Find("ChooseCanvas").transform.GetComponent<ChooseCanvasManager>().specialRole = this.GetComponent<SpecialNPCTalkManager>();
			GameObject.Find("World").transform.Find("ChooseCanvas").gameObject.SetActive(true);
			PlayerManager.Interaction = true;	
		}	
	}
}
