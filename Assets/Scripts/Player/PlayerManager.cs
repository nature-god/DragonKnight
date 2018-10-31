using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public static bool Interaction = false;
	public Player player;
	public GameObject PackageCanvas;
	public GameObject PlayerProfileCanvas;	
	public Animator anim;

	// Use this for initialization
	void Start () {
		player = GameManager.Instance.player;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Interaction)
		{
			if(Input.GetKey(KeyCode.W))
			{
				anim.SetFloat("Horizontal",1);
				anim.SetFloat("Vertical",0);
				this.GetComponent<RectTransform>().localPosition += new Vector3(0,GameManager.Instance.player.Move_speed*Time.deltaTime,0);
			}	
			else if(Input.GetKey(KeyCode.A))
			{
				anim.SetFloat("Horizontal",0);
				anim.SetFloat("Vertical",-1);
				this.GetComponent<RectTransform>().localPosition -= new Vector3(GameManager.Instance.player.Move_speed*Time.deltaTime,0,0);
			} 
			else if(Input.GetKey(KeyCode.S))
			{
				anim.SetFloat("Horizontal",-1);
				anim.SetFloat("Vertical",0);
				this.GetComponent<RectTransform>().localPosition -= new Vector3(0,GameManager.Instance.player.Move_speed*Time.deltaTime,0);
			}
			else if(Input.GetKey(KeyCode.D))
			{
				anim.SetFloat("Horizontal",0);
				anim.SetFloat("Vertical",1);
				this.GetComponent<RectTransform>().localPosition += new Vector3(GameManager.Instance.player.Move_speed*Time.deltaTime,0,0);
			}
			else if(Input.GetKeyDown(KeyCode.K))
			{
				PackageCanvas.SetActive(true);
				Interaction = true;
			}
			else if(Input.GetKeyDown(KeyCode.L))
			{
				PlayerProfileCanvas.SetActive(true);
				Interaction = true;
			}
		}
	}
}
