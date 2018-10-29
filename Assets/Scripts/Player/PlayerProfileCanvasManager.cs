using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileCanvasManager : MonoBehaviour {

	public Text basicMessageText;
	public Text ForceInformationText; 
	public Text MagicInformationText;

	private Player player;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			PlayerManager.Interaction = false;
			this.gameObject.SetActive(false);
		}
	}

	void OnEnable()
	{
		player = GameManager.Instance.player;
		basicMessageText.text =  "声望等级: " + "【"+player.Level+"】" + '\n'
								+"姓名: " + player.Name + '\n'
								+ "性别: " + player.Gender + '\n'
								+ "种族: " + player.Race + '\n'
								+ "生命值: " + player.Current_health + '/' + player.Health + '\n' 
								+ "体力值: " + player.Current_stamina + '/' + player.Stamina + '\n'
								+ "法术容量: " + player.Current_magic + '/' + player.Magic + '\n'
								+ "移动速度: " + player.Move_speed + '\n'
								+ "闪避: " + player.Dodge + '\n'
								+ "声望: " + player.Reputation + '\n'
								+ "头部装备: " + player.Head.Name + '\n'
								+ "护手装备: " + player.HandGuard.Name + '\n'
								+ "身体装备: " + player.Cloth.Name + '\n'
								+ "武器装备: " + player.Weapon.Name + '\n'
								+ "鞋子装备: " + player.Shoes.Name;

		ForceInformationText.text = "物攻: " + player.Force_attack + '\n'
								+ "物防: " + player.Force_defense + '\n'
								+ "物理命中: " + player.Force_hit + '\n'
								+ "物理暴击值: " + player.Force_critical + '\n'
								+ "物理暴击率: " + player.Force_probability;

		MagicInformationText.text = "法攻: " + player.Magic_attack + '\n'
								+ "法强: " + player.Magic_defense + '\n'
								+ "法术命中: " + player.Magic_hit + '\n'
								+ "法术暴击值: " + player.Magic_critical + '\n'
								+ "法术暴击率: " + player.Magic_probability;
	}
}
