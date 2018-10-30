using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

	public bool IsCooling;

	public int ClockCooling_Time;
	public BoxCollider2D boxCollider2D;
	private float tempTime;
	private float TempTime
	{
		set
		{
			if(value >= ClockCooling_Time)
			{
				tempTime = 0.0f;
				IsCooling = false;
			}
			else
			{
				tempTime = value;
			}
		}
		get
		{
			return tempTime;
		}
	} 
	// Use this for initialization
	void Awake () {
		IsCooling = false;
		tempTime = 0.0f;
		boxCollider2D = this.gameObject.transform.GetComponent<BoxCollider2D>();
		boxCollider2D.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(IsCooling)
		{
			TempTime += Time.deltaTime;
		}
	}

	public IEnumerator UseSkill(float temp)
	{
		IsCooling = true;
		boxCollider2D.enabled = true;
		yield return new WaitForSeconds(temp);
		boxCollider2D.enabled = false;
	}
}
