using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GolbinManager : MonsterManager {

	// Use this for initialization
	void Start () {
		Monster = new Golblin(MonsterName,Gender,Race,Level,
							Force_attack,Force_defense,Force_hit,Force_critical,Force_Probability,
							Magic_attack,Magic_defense,Magic_hit,Magic_critical,Magic_Probability,
							Health,Magic,Move_speed,Dodge,Health,Magic);
		AllSkills = new SkillManager[MonsterSkills.childCount];
		for(int i=0;i<MonsterSkills.childCount ;i++)
		{
			AllSkills[i] = MonsterSkills.GetChild(i).GetComponent<SkillManager>();
		}
		Monster.OnHealthChange = OnHealthChange;
		Monster.OnMagicChange =OnMagicChange;
		Monster.Dead = DropItem;
		Monster.Dead += MonsterDead;
		OnHealthChange(Monster.Current_health,Health);
		OnMagicChange(Monster.Current_magic,Magic);
	}
}
