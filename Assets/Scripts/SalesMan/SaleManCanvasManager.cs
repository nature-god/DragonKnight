using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleManCanvasManager : MonoBehaviour {

	public Text GoldText;
	public Text TalkText;
	public GameObject ItemPrefab;
	public Transform ItemsToBeSaled;

	public static SaleManManager SaleMan;
	
	private GameObject[] SaleItems;
	public RectTransform[] showItems;
	private Player player;
	//Cursor position
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
			else if(value >= SaleItems.Length)
			{
				ShowStartIndex++;
				chooseIndex = SaleItems.Length-1;
			}
			else if(value > 2)
			{
				ShowStartIndex++;
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

	//From which item start to sale
	private int showStartIndex;
	private int ShowStartIndex
	{
		set
		{
			if( value > (SaleItems.Length - 3))
			{
				//The last Page
				ShowStartIndex = SaleItems.Length - 3;
			}
			else if(value > SaleItems.Length)
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

	//How the Items UI show
	private int showStartnum;
	private int ShowStartnum
	{
		set
		{
			if(SaleItems.Length >= 4 && ShowStartIndex == SaleItems.Length - 3)
			{
				showStartnum = 3;
			}
			else if(value >= 4)
			{
				showStartnum = 4;
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
		chooseIndex = 0;
		showStartIndex = 0;
		showItems = new RectTransform[4];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
		{
			ChooseIndex--;
			ShowSaleItems();
		}
		else if(Input.GetKeyDown(KeyCode.S))
		{
			ChooseIndex++;
			ShowSaleItems();
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			PlayerManager.Interaction = false;
			this.gameObject.SetActive(false);
		}
		else if(Input.GetKeyDown(KeyCode.J))
		{
			Item tmp = SaleItems[ChooseIndex+ShowStartIndex].transform.GetComponent<ItemManager>().GetItem();
			//Use Item
			if(player.Gold > tmp.Price)
			{
				if(player.PlayerPackage.IsPlaceEnough(tmp))
				{
					player.Gold -= tmp.Price;
					player.PlayerPackage.AddItem(tmp);
					GoldText.text = "   Gold: "+player.Gold;
					TalkText.text = "这是你的【"+tmp.Name+"】";					
				}
				else
				{
					TalkText.text = "小家伙，换个大点的袋子来吧.";					
				}
			}
			else
			{
				TalkText.text = "小家伙，你没有足够的金币.";
			}
		}
	}

	void ShowSaleItems()
	{
		GoldText.text = "   Gold: "+player.Gold;
		ClearShow();
		ShowStartnum = SaleItems.Length;

		//all Items can be show
		if(ShowStartnum < 4)
		{
			for(int i = 0;i<ShowStartnum;i++)
			{
				showItems[i] = Instantiate(ItemPrefab,ItemsToBeSaled).GetComponent<RectTransform>();
				showItems[i].localPosition = new Vector3(-436.0f,225-140*i,0f);

				showItems[i].GetChild(2).GetComponent<Text>().text = SaleItems[showStartIndex+i].transform.GetComponent<ItemManager>().Show();
				showItems[i].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);		

			}

			showItems[ShowStartnum] = Instantiate(ItemPrefab,ItemsToBeSaled).GetComponent<RectTransform>();
			showItems[ShowStartnum].localPosition = new Vector3(-436.0f,225-140*(ShowStartnum),0f);
			showItems[ShowStartnum].GetChild(2).GetComponent<Text>().text = "没有更多的物品啦";
			showItems[ShowStartnum].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);		

		}
		else
		{
			showItems[0] = Instantiate(ItemPrefab,ItemsToBeSaled).GetComponent<RectTransform>();
			showItems[1] = Instantiate(ItemPrefab,ItemsToBeSaled).GetComponent<RectTransform>();
			showItems[2] = Instantiate(ItemPrefab,ItemsToBeSaled).GetComponent<RectTransform>();
			showItems[3] = Instantiate(ItemPrefab,ItemsToBeSaled).GetComponent<RectTransform>();
			for(int i = 0;i<4;i++)
			{
				showItems[i].localPosition = new Vector3(-436.0f,225-150*i,0f);
				showItems[i].GetChild(2).GetComponent<Text>().text = SaleItems[showStartIndex+i].transform.GetComponent<ItemManager>().Show();
				showItems[i].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);						
			}
		}
		showItems[ChooseIndex].GetChild(0).GetComponent<Image>().color = new Color(200.0f/255.0f,90.0f/255.0f,90.0f/255.0f);		
	}
	void ClearShow()
	{
		int childCount = ItemsToBeSaled.childCount;
		for(int i = 0;i<childCount;i++)
		{
			Destroy(ItemsToBeSaled.GetChild(i).gameObject);
		}
	}
	void OnEnable()
	{
		TalkText.text = SaleMan.WelcomeTalk;
		chooseIndex = 0;
		showStartIndex = 0;
		SaleItems = SaleMan.SaleThings;
		player = GameManager.Instance.player;
		ShowSaleItems();
	}
}
