using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Just for UI show not logic related
public class ChooseCanvasManager : MonoBehaviour {

	public string[] Selections;
	public GameObject ChooseItemPrefab;
	public Transform ChooseItems;
	public GameObject Cursor;
	public Text DefaultSentense;

	public static string DefaultLines;
	public SpecialNPCTalkManager specialRole;
	private int chooseIndex;
	private int ChooseIndex
	{
		set
		{
			if(value < 0)
			{
				chooseIndex = 0;
			}
			else if(value > Selections.Length-1)
			{
				chooseIndex = Selections.Length -1;
			}
			else if(value > 2)
			{
				chooseIndex = 2;
			}
			else
			{
				chooseIndex = value;
			}
		}
		get
		{
			return chooseIndex;
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
		{
			ChooseIndex--;
			Cursor.transform.GetComponent<RectTransform>().localPosition = new Vector3(-360.0f,-228.0f-55*ChooseIndex,0f);
		}
		else if(Input.GetKeyDown(KeyCode.S))
		{
			ChooseIndex++;
			Cursor.transform.GetComponent<RectTransform>().localPosition = new Vector3(-360.0f,-228.0f-55*ChooseIndex,0f);
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			PlayerManager.Interaction = false;	
			this.gameObject.SetActive(false);
		}
		else if(Input.GetKeyDown(KeyCode.J))
		{
			//specialRole.xxxx
			specialRole.Choose(ChooseIndex);
			this.gameObject.SetActive(false);			
		}
	}

	void OnEnable()
	{
		chooseIndex = 0;
		Cursor.transform.GetComponent<RectTransform>().localPosition = new Vector3(-360.0f,-228.0f,0f);
		for(int i=0;i<Selections.Length;i++)
		{
			GameObject tmp = Instantiate(ChooseItemPrefab,ChooseItems);
			tmp.transform.localPosition = new Vector3(0,0-54*i,0);
			tmp.transform.GetChild(1).GetComponent<Text>().text = Selections[i];
		}
		DefaultSentense.text = DefaultLines;
	}
}
