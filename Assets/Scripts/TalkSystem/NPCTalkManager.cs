using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkManager : MonoBehaviour {

	private string roleFileName;
	private string roleLines;
	// Use this for initialization
	void Start () {
		roleFileName = this.transform.name + ".xml";
		roleLines = LoadLines.ReadXML(roleFileName);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D tmp) 
	{
		if(tmp.gameObject.CompareTag("Player"))
		{
			TalkCanvasManager.talkContent = roleLines;
			GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
			PlayerManager.Interaction = true;			
		}	
	}
}
