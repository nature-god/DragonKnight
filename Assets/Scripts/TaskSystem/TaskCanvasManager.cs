using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskCanvasManager : MonoBehaviour {

	public Text TaskDescription;
	public DetermineCanvasManager determineCanvasManager;
	public GameObject ItemPrefab;
	public Transform TasksToBeShow;
	public List<Task> Tasks;
	public RectTransform[] showItems;
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
			else if(value >= Tasks.Count)
			{
				ShowStartIndex++;
				chooseIndex = Tasks.Count-1;
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
			if( value > (Tasks.Count - 3))
			{
				//The last Page
				ShowStartIndex = Tasks.Count - 3;
			}
			else if(value > Tasks.Count)
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
			if(Tasks.Count >= 4 && ShowStartIndex == Tasks.Count - 3)
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
		Tasks = TaskManager.Instance.tasks;
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
			Task tmp = Tasks[ChooseIndex+ShowStartIndex];
			determineCanvasManager.OptionActivities = (_option)=>{
				if(_option)
				{
					Debug.Log(tmp.CompleteTask());
					if(tmp.CompleteTask())
					{
						tmp.Reward();
						Tasks.Remove(tmp);
						TalkCanvasManager.talkContent = "交付任务成功，这是您的报酬，请收好";
						GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
					}
					else
					{
						TalkCanvasManager.talkContent = "任务尚未完成，无法交付哦~";
						GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
					}
				}
				else
				{
					TalkCanvasManager.talkContent = "加油，奖赏是永远留给冒险者.";
					GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
				}
			};
			determineCanvasManager.DefaultSentense.text = "您确定要交付任务么?";
			determineCanvasManager.gameObject.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}

	void ShowSaleItems()
	{
		ClearShow();
		ShowStartnum = Tasks.Count;

		//all Items can be show
		if(ShowStartnum < 4)
		{
			for(int i = 0;i<ShowStartnum;i++)
			{
				showItems[i] = Instantiate(ItemPrefab,TasksToBeShow).GetComponent<RectTransform>();
				showItems[i].localPosition = new Vector3(-436.0f,225-140*i,0f);

				showItems[i].GetChild(2).GetComponent<Text>().text = Tasks[showStartIndex+i].Task_name;
				TaskDescription.text = Tasks[showStartIndex+i].Description;
				showItems[i].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);		

			}

			showItems[ShowStartnum] = Instantiate(ItemPrefab,TasksToBeShow).GetComponent<RectTransform>();
			showItems[ShowStartnum].localPosition = new Vector3(-436.0f,225-140*(ShowStartnum),0f);
			showItems[ShowStartnum].GetChild(2).GetComponent<Text>().text = "没有更多的任务啦";
			showItems[ShowStartnum].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);		

		}
		else
		{
			showItems[0] = Instantiate(ItemPrefab,TasksToBeShow).GetComponent<RectTransform>();
			showItems[1] = Instantiate(ItemPrefab,TasksToBeShow).GetComponent<RectTransform>();
			showItems[2] = Instantiate(ItemPrefab,TasksToBeShow).GetComponent<RectTransform>();
			showItems[3] = Instantiate(ItemPrefab,TasksToBeShow).GetComponent<RectTransform>();
			for(int i = 0;i<4;i++)
			{
				showItems[i].localPosition = new Vector3(-436.0f,225-150*i,0f);
				showItems[i].GetChild(2).GetComponent<Text>().text = Tasks[showStartIndex+i].Task_name;
				TaskDescription.text = Tasks[showStartIndex+i].Description;
				showItems[i].GetChild(0).GetComponent<Image>().color = new Color(84.0f/255.0f,84.0f/255.0f,84.0f/255.0f);						
			}
		}
		showItems[ChooseIndex].GetChild(0).GetComponent<Image>().color = new Color(200.0f/255.0f,90.0f/255.0f,90.0f/255.0f);		
	}
	void ClearShow()
	{
		int childCount = TasksToBeShow.childCount;
		for(int i = 0;i<childCount;i++)
		{
			Destroy(TasksToBeShow.GetChild(i).gameObject);
		}
	}
	void OnEnable()
	{
		chooseIndex = 0;
		showStartIndex = 0;
		Tasks = TaskManager.Instance.tasks;
		ShowSaleItems();
	}
}
