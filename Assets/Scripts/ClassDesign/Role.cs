//This class is designed for the all role in the game
//By nature 2018.10.8
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role{
	private string name;				//role name
	private int gender;					//4 kinds of sex
	private string race;				//Different race
	private int level;					//The Level of the Role , for 7 levels

	private int force_attack;			//The force attack
	private int force_defense;			//The force defense
	private int force_hit;				//The force hit		[0,100]
	private float force_critical;		//The max num of Critical force hit
	private int force_probability;		//The propability of Critical force hit [0,40]
	
	private int magic_attack;			//The magic attack	[0,1000]
	private int magic_defense;			//The magic defense	[0,1000]
	private int magic_hit;				//The magic hit		[0,100]
	private float magic_critical;		//The max num of Critical magic hit
	private int magic_probability;		//The probability of Critical magic hit

	private int health;					//The max num of life
	private int magic;					//The max num of magic
	private int move_speed;				//The move speed
	private int dodge;					//The dodge			[0,100]
	private int current_health;			//The current num of life
	private int current_magic;			//The current num of magic

	public List<status> role_status;	//The status of the role
	public List<Skill> role_skills;		//The skills of the role

#region  attributes accessors
	public string Name
	{
		get
		{
			return name;
		}
	}
	public string Gender
	{
		get
		{
			switch (gender)
			{
				case 0:
				{
					return "Male";
				}
				case 1:
				{
					return "Female";
				}
				case 2:
				{
					return "No gender";
				}
				case 3:
				{
					return "Monoecious";
				}
				default:
				{
					return "Unknow";
				}
			}
		}
	}
	public string Race
	{
		get
		{
			return race;
		}
	}
	public string Level
	{
		get
		{
			switch(level)
			{
				case 0:
				{
					return "菜鸟级";
				}
				case 1:
				{
					return "新手级";
				}
				case 2:
				{
					return "冒险家";
				}
				case 3:
				{
					return "大师级";
				}
				case 4:
				{
					return "传奇级";
				}
				case 5:
				{
					return "圣域级";
				}
				case 6:
				{
					return "星空级";
				}
				case 7:
				{
					return "大帝";
				}
				default:
				{
					return "Level Error";
				}
			}
		}
	}
	public int Force_attack
	{
		set
		{
			force_attack = value;
		}
		get
		{
			return force_attack;
		}
	}
	public int Force_defense
	{
		set
		{
			force_defense = value;
		}
		get
		{
			return force_defense;
		}
	}
	public int Force_hit
	{
		set
		{
			force_hit = value;
		}
		get
		{
			return force_hit;
		}
	}
	public float Force_critical
	{
		set
		{
			force_critical = value;
		}
		get
		{
			return force_critical;
		}
	}
	public int Force_probability
	{
		set
		{
			force_probability = value;
		}
		get
		{
			return force_probability;
		}
	}
	public int Magic_attack
	{
		set
		{
			magic_attack = value;
		}
		get
		{
			return magic_attack;
		}
	}
	public int Magic_defense
	{
		set
		{
			magic_defense = value;
		}
		get
		{
			return magic_defense;
		}
	}
	public int Magic_hit
	{
		set
		{
			magic_hit = value;
		}
		get
		{
			return magic_hit;
		}
	}
	public float Magic_critical
	{
		set
		{
			magic_critical = value;
		}
		get
		{
			return magic_critical;
		}
	}
	public int Magic_probability
	{
		set
		{
			magic_probability = value;
		}
		get
		{
			return magic_probability;
		}
	}
	public int Health
	{
		get
		{
			return health;
		}
	}
	public int Magic
	{
		set
		{
			magic = value;
		}
		get
		{
			return magic;
		}
	}
	public int Move_speed
	{
		set
		{
			move_speed = value;
		}
		get
		{
			return move_speed;
		}
	}
	public int Dodge
	{
		set
		{
			dodge = value;
		}
		get
		{
			return dodge;
		}
	}
	public int Current_health
	{
		set
		{
			if(value <= 0)
			{
				//The role Dead
				current_health = 0;
				Dead();
			}
			else if(value >= health)
			{
				//The max health
				current_health = health;
			}
			else
			{
				current_health = value;
			}
		}
		get
		{
			return current_health;
		}
	}
	public int Current_magic
	{
		set
		{
			if(value <= 0)
			{
				current_magic = 0;
			}
			else if(value >= Magic)
			{
				current_magic = Magic;
			}
			else
			{
				current_magic = value;
			}
		}
		get
		{
			return current_magic;
		}
	}
#endregion

	///<summary>The Constructor of Role Class</summary>
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
	public Role(string _name,int _gender,string _race,int _level,
				int _force_attack,int _force_defense,int _force_hit,float _force_critical,int _force_probability,
				int _magic_attack,int _magic_defense,int _magic_hit,float _magic_critical,int _magic_probability,
				int _health,int _magic,int _move_speed,int _dodge,int _current_health,int _current_magic)
				{
					name = _name;
					gender = _gender;
					race = _race;
					level = _level;
					force_attack = _force_attack;
					force_defense = _force_defense;
					force_hit = _force_hit;
					force_critical = _force_critical;
					force_probability = _force_probability;
					magic_attack = _magic_attack;
					magic_defense = _magic_defense;
					magic_hit = _magic_hit;
					magic_critical = _magic_critical;
					magic_probability = _magic_probability;
					health = _health;
					magic = _magic;
					move_speed = _move_speed;
					dodge = _dodge;
					current_health = _current_health;
					current_magic = _current_magic;
				}
	#region  need to be modified soon , because there are many problems
	public void UseSkill(Role customer,Skill skill)
	{
		skill.SkillEffect(this,customer);
	}
	public void Dead()
	{
		Debug.Log("In RoleCalss.cs : "+Name + " is dead.");
	}
	#endregion	
}
