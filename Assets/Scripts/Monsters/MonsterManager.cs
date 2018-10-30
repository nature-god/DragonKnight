using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour {

	public string MonsterName;
	public int Gender;
	public string Race;
	public int Level;
	public int Force_attack;
	public int Force_defense;
	public int Force_hit;
	public int Force_critical;
	public int Force_Probability;
	public int Magic_attack;
	public int Magic_defense;
	public int Magic_hit;
	public int Magic_critical;
	public int Magic_Probability;

	public int Health;
	public int Magic;
	public int Move_speed;
	public int Dodge;

	public Role Monster;
	public Slider HealthSlider;
	public Slider MagicSlider;
	public Transform MonsterSkills;
	public SkillManager[] AllSkills;
	public enum MonsterStatus
	{
		Normal = 0,
		Attack = 1,
		Escape = 2
	};
	public MonsterStatus _MonsterStatus;
	public Transform AttackTarget;
}
