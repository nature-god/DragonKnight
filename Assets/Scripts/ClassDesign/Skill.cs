//This is for the Player Skills , include force and magic
//By nature
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill{
	private string skill_name;		//Skill Name
	private int cooling_time;		//The time for the next use
	private string description;		//The description of the skills
	private int cost;				//Use skill will cost some attribute

	#region accessors
	public string Name
	{
		get
		{
			return skill_name;
		}
	}
	public int Cooling_time
	{
		get
		{
			return cooling_time;
		}
	}
	public string Description
	{
		get
		{
			return description;
		}
	}
	public int Cost
	{
		get
		{
			return cost;
		}
	}
	#endregion

	///<summary>Constructor</summary>
	///<param name="skill_name">Skill Name</param>
	///<param name="cooling_time">The time for the next use</param>
	///<param name="description">The description of the skills</param>
	public Skill(string _name,int _cooling_time,int _cost,string _description)
	{
		skill_name = _name;
		cooling_time = _cooling_time;
		cost = _cost;
		description = _description;
	}

	///<summary>The Extra effect the skill give</summary>
	///<param name="User">The role to use the skill</param>
	///<param name="Customer">The role to get the skill effect</param>
	public virtual void SkillEffect(Role user,Role customer){}

	///<summary>Judge whether Critical Hit</summary>
	///<param name="probability">The ptobility of the attack</param>
	///<return>true,Critical Hit; False normal Hit</return>
	protected bool CriticalHitHelper(int probability)
	{
		int temp = Random.Range(0,100);
		if(temp < probability)
		{
			Debug.Log("Critical Hit !");
			return true;
		}
		else
		{
			Debug.Log("Normal Hit !");
			return false;
		}
	}

	///<summary>Judge whether this special magic hit enemy
	///<param name="user">The role to use skill</param>
	///<param nmae="customer">The role to get the skill</param>
	///<return>true, hit the customer</return>
	protected bool SpecialMagicHitHelper(Role user,Role customer)
	{
		int temp = Random.Range(0,100);
		int pro = (int)( 1.0f * (user.Magic_hit - customer.Dodge)/user.Magic_hit * 100);
		if(temp < pro)
		{
			Debug.Log("Hit Customer!");
			return true;
		} 
		else
		{
			Debug.Log("Not Hit Customer!");
			return false;
		}
	}
}

public abstract class ForceSkill : Skill
{
	private int extra_attack;		//The extra attack

	///<summary>Constructor</summary>
	public ForceSkill(string _name,int _cooling_time,int _cost,string _description,int _extra_attack) : base(_name,_cooling_time,_cost,_description)
	{
		extra_attack = _extra_attack;
	}

	protected void ForceAttackHelper(Role user,Role customer)
	{
		float tmp = 1.0f;
		float damage = 0.0f;
		if(CriticalHitHelper(user.Force_probability))
		{
			//Critical Hit!
			tmp = user.Force_critical;
		}
		else
		{
			tmp = 1.0f;
		}
		if(user.GetType().Equals(typeof(Player)))
		{
			//Player have weapon attack add;
			//Player Use Force Skill should cost stamina
			if((user as Player).Stamina < Cost)
			{
				Debug.Log("not enough stamina");
				return;
			}
			else
			{
				(user as Player).Stamina -= Cost;
			}
			damage = (user.Force_attack*tmp+extra_attack)*(user.Force_hit-customer.Dodge)/user.Force_hit - customer.Force_defense;

		}
		else
		{
			//Other races have no weapon attack add;
			damage = (user.Force_attack*tmp+extra_attack)*(user.Force_hit-customer.Dodge)/user.Force_hit - customer.Force_defense;
		}
		if(damage <= 0)
		{
			damage = 1;
		}
		customer.Current_health -= (int)damage;
	}
}

public abstract class MagicSkill : Skill
{
	private int extra_attack;		//The extra attack

	///<summary>Constructor</summary>
	public MagicSkill(string _name,int _cooling_time,int _cost,string _description,int _extra_attack) : base(_name,_cooling_time,_cost,_description)
	{
		extra_attack = _extra_attack;
	}

	///<summary>Attack Enemy in Force</summary>
	///<param name="User">The role to use the skill</param>
	///<param name="Customer">The role to get the skill effect</param>
	protected void MagicAttackHelper(Role user,Role customer)
	{
		if(user.Magic < Cost)
		{
			Debug.Log("Magic is not enough");
			return;
		}
		else
		{
			user.Magic -= Cost;
		}
		float tmp = 1.0f;
		float damage = 0.0f;
		if(CriticalHitHelper(user.Magic_probability))
		{
			//Critical Hit!
			tmp = user.Magic_critical;
		}
		else
		{
			tmp = 1.0f;
		}
		damage = (user.Magic_attack*tmp+extra_attack)*(user.Magic_hit-customer.Dodge)/user.Magic_hit - customer.Magic_defense;
		if(damage <= 0)
		{
			damage = 1;
		}
		customer.Current_health -= (int)damage;
	}
}

public abstract class SpecialMagicSkill : Skill
{
	public SpecialMagicSkill(string _name,int _cooling_time,int _cost,string _description) : base(_name,_cooling_time,_cost,_description)
	{

	}

	///<summary>Whether the role have enough magic to use skill</summary>
	///<param name="user">The role to use the magic</param>
	///<return>True, if the magic is enough</return>
	protected bool SpecialMagicHelper(Role user)
	{
		if(user.Magic < Cost)
		{
			Debug.Log("Not enough magic");
			return false;
		}
		else
		{
			user.Magic -= Cost;
			return true;
		}
	}
}
