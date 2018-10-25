using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetermineCanvasManager : MonoBehaviour {

	public RectTransform Cursor;
	public Text DefaultSentense;
	public delegate void optionActivity(bool _option);
	public optionActivity OptionActivities;

	private bool option;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S))
		{
			if(option)
			{
				option = false;
				Cursor.localPosition = new Vector3(-360.0f,-310.0f,0.0f);
			}
		}
		else if(Input.GetKeyDown(KeyCode.W))
		{
			if(!option)
			{
				option = true;
				Cursor.localPosition = new Vector3(-360.0f,-250.0f,0.0f);
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			PlayerManager.Interaction = false;	
			this.gameObject.SetActive(false);
		}
		else if(Input.GetKeyDown(KeyCode.J))
		{
			OptionActivities(option);
			this.gameObject.SetActive(false);
		}
	}

	void OnEnable()
	{
		option = false;
		Cursor.localPosition = new Vector3(-360.0f,-310.0f,0.0f);
	}
}
