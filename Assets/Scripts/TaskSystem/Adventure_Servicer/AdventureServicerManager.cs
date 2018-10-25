using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureServicerManager : SpecialNPCTalkManager {

	public DetermineCanvasManager deterMineCanvasManager;

	public override void Choose(int option)
	{
		switch (option)
		{
			case 0:
			{
				if(AdventureBook.Instance.GetNumWithKey("IsAdventurer")==0)
				{
					deterMineCanvasManager.OptionActivities = DetermineChoose;
					deterMineCanvasManager.DefaultSentense.text = "缴纳20金币即可成为冒险者！\n公会附送一本冒险者记录日志与一把新手武器呢~";
					deterMineCanvasManager.gameObject.SetActive(true);
				}
				else
				{
					TalkCanvasManager.talkContent = "您已经是一位冒险者了哦.";
					GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
				}
				break;
			}
			case 1:
			{
				if(AdventureBook.Instance.GetNumWithKey("IsAdventurer")==0)
				{
					TalkCanvasManager.talkContent = "很抱歉，只有冒险者才能查看冒险者任务.";
					GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
				}
				else
				{
					GameObject.Find("World").transform.Find("TaskShowCanvas").gameObject.SetActive(true);
				}	
				break;
			}
			case 2:
			{
				if(AdventureBook.Instance.GetNumWithKey("IsAdventurer")==0)
				{
					TalkCanvasManager.talkContent = "很抱歉，只有冒险者才能评定等级.";
					GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
				}
				else
				{
					deterMineCanvasManager.OptionActivities = Evaluation;
					deterMineCanvasManager.DefaultSentense.text = "卡拉冒险者公会\n"
																+ "此处可评:\n"
																+ "【菜鸟级】=>【新手级】:讨伐成功5只新手级怪物,声望达到100\n"
																+ "【新手级】=>【冒险家级】:讨伐成功20只新手级怪物，1只冒险家级怪物，声望达到500\n"
																+ "【冒险家级】=>【大师级】:讨伐成功20只冒险家级怪物，1只大师级怪物，声望达到1000\n"
																+ "【大师级】=>【传奇级】:讨伐成功20只大师级怪物，1只传奇级怪物，声望达到2000\n"
																+ "【传奇级】=>【圣域级】:讨伐成功20只传奇级怪物，1只圣域级怪物，声望达到5000\n"
																+ "【圣域级】=>【星空级】:讨伐成功20只圣域级怪物，1只星空级怪物，声望达到10000\n"
																+ "【星空级】=>【大帝级】:到达坎帕斯神庙，声望达到20000\n"
																+ "您现在是【" + GameManager.Instance.player.Level + "】\n"
																+ "请问您想评下一个等级么?";
					deterMineCanvasManager.gameObject.SetActive(true);
				}
				break;
			}
			default:
			{
				Debug.Log("Option ??");
				break;
			}
		}
	}
	public void DetermineChoose(bool _option)
	{
		if(_option)
		{
			if(GameManager.Instance.player.Gold >= 20)
			{
				AdventureBook.Instance.AddRecord("IsAdventurer",1);
				GameManager.Instance.player.Gold -= 20;
				TalkCanvasManager.talkContent = "恭喜您，您现在成为一位冒险家了!";
				GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
			}
			else
			{
				TalkCanvasManager.talkContent = "对不起，您的金币数量不足呢.";
				GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
			}
		}
		else
		{
			TalkCanvasManager.talkContent = "很高兴为您服务，欢迎下次光临.";
			GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
		}
	}
	public void Evaluation(bool _option)
	{
		if(_option)
		{
			if(GameManager.Instance.player.LevelEvaluation())
			{
				TalkCanvasManager.talkContent = "进阶成功，您现在是【"+GameManager.Instance.player.Level+"】冒险者了.";
				GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
			}
			else
			{
				TalkCanvasManager.talkContent = "您还不能跨过阶级之间的壁垒.";
				GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
			}
		}
		else
		{
			TalkCanvasManager.talkContent = "很高兴为您服务，欢迎下次光临.";
			GameObject.Find("World").transform.Find("TalkCanvas").gameObject.SetActive(true);
		}
	}
}
