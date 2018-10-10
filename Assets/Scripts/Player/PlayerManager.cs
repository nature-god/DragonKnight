using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
		{
			this.GetComponent<RectTransform>().localPosition += new Vector3(0,GameManager.Instance.player.Move_speed*Time.deltaTime,0);
		}	
		else if(Input.GetKey(KeyCode.A))
		{
			this.GetComponent<RectTransform>().localPosition -= new Vector3(GameManager.Instance.player.Move_speed*Time.deltaTime,0,0);
		} 
		else if(Input.GetKey(KeyCode.S))
		{
			this.GetComponent<RectTransform>().localPosition -= new Vector3(0,GameManager.Instance.player.Move_speed*Time.deltaTime,0);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			this.GetComponent<RectTransform>().localPosition += new Vector3(GameManager.Instance.player.Move_speed*Time.deltaTime,0,0);
		}
	}
}
