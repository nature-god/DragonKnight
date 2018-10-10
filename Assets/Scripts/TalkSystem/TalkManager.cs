using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour {

	public static string talkContent;
	public Text showText;

	private bool over = false;
	// Use this for initialization
	void Start () {
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(over)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				this.gameObject.SetActive(false);
			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				StopCoroutine(ShowText());
				over = true;
				showText.text = talkContent;
			}	
		}
		
	}

	IEnumerator ShowText()
	{
		//Debug.Log(talkContent.Length);
		for(int i=0;i<talkContent.Length;i++)
		{
			if(over)
			{
				break;
			}
			showText.text += talkContent[i];
			yield return new WaitForSeconds(0.1f);
		}
		over = true;
	}

	void OnEnable()
	{
		showText.text = "";
		over = false;
		StartCoroutine(ShowText());
	}
}
