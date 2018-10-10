using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	private float timeFrame;
	private float TimeFrame
	{
		set
		{
			if(value > 1.0f)
			{
				timeFrame = 0.0f;
				//Status Here
			}
			else
			{
				timeFrame = value;
			}
		}
		get	
		{
			return timeFrame;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeFrame += Time.deltaTime;
	}
}
