//This is Player class
//By nature
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Role
{
	private int stamina;							//Max stamina, player use force skill and some other thing all need this
	private int current_stamina;					//Current stamina
	private int reputation;							//The reputation can be get through tasks and kill monsters
	private int gold;								//The player's gold

	public HeadEquipment Head;
	public ClothEquipment Cloth;
	public HandGuardEquipment HandGuard;
	public WeaponEquipment Weapon;
	public ShoesEquipment Shoes;

	public Pet[] Pets;

	#region new attributes' accessors
	public int Stamina
	{
		set
		{
			stamina = value;
		}
		get
		{
			return stamina;
		}
	}
	public int Current_stamina
	{
		get
		{
			return current_stamina;
		}
	}
	public int Reputation
	{
		get
		{
			return reputation;
		}
	}
	public int Gold
	{
		set
		{
			if(value < 0)
			{
				Debug.Log("gold is not enough!");
			}
			else
			{
				gold = value;
			}
		}
		get
		{
			return gold;
		}
	}
	#endregion

	///<summary>The Constructor of Player Class</summary>
	///<param name="_name">name</param>
	///<param name="_sex">sex</param>
	///<param name="_race">race</param>
	///<param name="_level">level</param>
	///<param name="_force_attack">The force attack</param>
	///<param name="_force_defense">The force defense</param>
	///<param name="_force_hit">The force hit</param>
	///<param name="_force_critical">The max num of Critical force hit</param>
	///<param name="_force_probability">The propability of Critical force hit</param>
	///<param name="_magic_attack">The magic attack</param>
	///<param name="_magic_defense">The magic defense</param>
	///<param name="_magic_hit">The magic hit</param>
	///<param name="_magic_critical">The max num of Critical magic hit</param>
	///<param name="_magic_probability">The probability of Critical magic hit</param>
	///<param name="_health">The max num of life</param>
	///<param name="_magic">The max num of magic</param>
	///<param name="_move_speed">The move speed</param>
	///<param name="_dodge">The dodge</param>
	///<param name="_current_health">The current num of health</param>
	///<param name="_current_magic">The current num og magic</param>
	///<param name="_stamina">Max stamina, player use force skill and some other thing all need this</param>
	///<param name="_current_stamina">Current stamina</param>
	///<param name="_reputation">The reputation can be get through tasks and kill monsters</param>
	///<param name="_gold">The player's gold</param>
	public Player(string _name,int _gender,string _race,int _level,
				int _force_attack,int _force_defense,int _force_hit,float _force_critical,int _force_probability,
				int _magic_attack,int _magic_defense,int _magic_hit,float _magic_critical,int _magic_probability,
				int _health,int _magic,int _move_speed,int _dodge,int _current_health,int _current_magic,
				int _stamina,int _current_stamina,int _reputation,int _gold)
				:base(_name,_gender,_race,_level,_force_attack,_force_defense,_force_hit,_force_critical,_force_probability,_magic_attack,
				_magic_defense,_magic_hit,_magic_critical,_magic_probability,_health,_magic,_move_speed,_dodge,_current_health,_current_magic)
				{
					stamina = _stamina;
					current_stamina = _current_stamina;
					reputation = _reputation;
					gold = _gold;
					Head = new HeadEquipment();
					Shoes = new ShoesEquipment();
					Cloth = new ClothEquipment();
					Weapon = new WeaponEquipment();
					HandGuard = new HandGuardEquipment();
				}
	
	///<summary>Show the more information of player</summary>
	public void Show()
	{
		Debug.Log("Name: " + Name + '\n'
				+ "Gender: " + Gender + '\n'
				+ "Race: " + Race + '\n'
				+ "Level: " + Level + '\n'
				+ "Force_attack: " + Force_attack + '\n'
				+ "Force_defense: " + Force_defense + '\n'
				+ "Force_hit: " + Force_hit + '\n'
				+ "Force_critical: " + Force_critical + '\n'
				+ "Force_probability: " + Force_probability + '\n'
				+ "Magic_attack: " + Magic_attack + '\n'
				+ "Magic_defense: " + Magic_defense + '\n'
				+ "Magic_hit: " + Magic_hit + '\n'
				+ "Magic_critical: " + Magic_critical + '\n'
				+ "Magic_probability: " + Magic_probability + '\n'
				+ "Health: " + Current_health + '/' + Health + '\n' 
				+ "Magic: " + Current_magic + '\n' + Magic + '\n'
				+ "Move_speed: " + Move_speed + '\n'
				+ "Dodge: " + Dodge + '\n'
				+ "Stamina: " + Current_stamina + '/' + Stamina + '\n'
				+ "Reputation: " + Reputation + '\n'
				+ "Gold" + Gold);
	}
}
