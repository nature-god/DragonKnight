using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageCanvasManager : MonoBehaviour {

	public GameObject ItemPrefab;
	public Text PackageSpaceText;
	public Text GoldNumText;

	public Transform ItemsInPackage;

	private Package package;
	private Transform[] showItems;
 
	private int chooseIndex;
	private int ChooseIndex
	{
		set
		{
			if(value < 0)
			{
				ShowStartIndex--;
				chooseIndex = 0;
			}
			else if(value >= package.GetItemsNum())
			{
				ShowStartIndex++;
				chooseIndex = package.GetItemsNum()-1;
			}
			else if(value > 3)
			{
				ShowStartIndex++;
				chooseIndex = 3;
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

	private int showStartIndex;
	private int ShowStartIndex
	{
		set
		{
			if( value > (package.GetItemsNum() - 4))
			{
				//The last Page
				ShowStartIndex = package.GetItemsNum() - 4;
			}
			else if(value > package.GetItemsNum())
			{
				showStartIndex = 0;
			}
			else if(value < 0)
			{
				//The First Page
				showStartIndex = 0;
			}
			else
			{
				//other Page
				showStartIndex = value;
			}
		}
		get
		{
			return showStartIndex;
		}
	}

	private int showStartnum;
	private int ShowStartnum
	{
		set
		{
			if(package.GetItemsNum() >= 5 && ShowStartIndex == package.GetItemsNum() - 4)
			{
				showStartnum = 4;
			}
			else if(value >= 5)
			{
				showStartnum = 5;
			}
			else
			{
				showStartnum = value;
			}
		}
		get
		{
			return showStartnum;
		}
	}

	// Use this for initialization
	void Awake () {
		showItems = new Transform[5];
		showStartIndex = 0;
		chooseIndex = 0;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			ChooseIndex--;
			ShowAllItems();

		}
		else if(Input.GetKeyDown(KeyCode.S))
		{
			ChooseIndex++;
			ShowAllItems();
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			PlayerManager.Interaction = false;
			this.gameObject.SetActive(false);
		}
		else if(Input.GetKeyDown(KeyCode.J))
		{
			//Use Item
			Item tmp = package.items[ChooseIndex+ShowStartIndex];

			tmp.UseItem(GameManager.Instance.player);
			package.RemoveItem(tmp);
			showStartIndex = 0;
			chooseIndex = 0;
			ShowAllItems();
		}
	}

	void ShowAllItems()
	{
		ClearShow();
		PresentItems();
		PackageSpaceText.text = "背包空间: " + package.TakedSpace + "/" + package.MaxSpace;
		GoldNumText.text = "金币: " + GameManager.Instance.player.Gold;
	}

	void ClearShow()
	{
		int childCount = ItemsInPackage.childCount;
		for(int i = 0;i<childCount;i++)
		{
			Destroy(ItemsInPackage.GetChild(i).gameObject);
		}
	}

	//Show 4.5 items
	void PresentItems()
	{
		ShowStartnum = package.GetItemsNum();
		if(ShowStartnum < 5)
		{
			for(int i = 0;i<ShowStartnum;i++)
			{
				showItems[i] = Instantiate(ItemPrefab,ItemsInPackage).transform;
				showItems[i].localPosition = new Vector3(-440.0f,200-150*i,0f);

				showItems[i].GetChild(2).GetComponent<Text>().text = package.items[showStartIndex+i].ItemMessage();
				showItems[i].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);		

			}

			showItems[ShowStartnum] = Instantiate(ItemPrefab,ItemsInPackage).transform;
			showItems[ShowStartnum].localPosition = new Vector3(-440.0f,200-150*(ShowStartnum),0f);
			showItems[ShowStartnum].GetChild(2).GetComponent<Text>().text = "没有更多的物品啦";
			showItems[ShowStartnum].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);		

		}
		else
		{
			showItems[0] = Instantiate(ItemPrefab,ItemsInPackage).transform;
			showItems[1] = Instantiate(ItemPrefab,ItemsInPackage).transform;
			showItems[2] = Instantiate(ItemPrefab,ItemsInPackage).transform;
			showItems[3] = Instantiate(ItemPrefab,ItemsInPackage).transform;
			showItems[4] = Instantiate(ItemPrefab,ItemsInPackage).transform;
			for(int i = 0;i<5;i++)
			{
				showItems[i].localPosition = new Vector3(-440.0f,200-150*i,0f);
				showItems[i].GetChild(2).GetComponent<Text>().text = package.items[showStartIndex+i].ItemMessage();
				showItems[i].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);		

			}
		}	
		showItems[ChooseIndex].GetChild(0).GetComponent<Image>().color = new Color(200.0f/255.0f,90.0f/255.0f,90.0f/255.0f);		
	}

	void OnEnable()
	{
		showStartIndex = 0;
		chooseIndex = 0;
		package = GameManager.Instance.player.PlayerPackage;
		Debug.Log("Package items' num is :"+package.GetItemsNum());
		ShowAllItems();
	}
}
