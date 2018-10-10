using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : Role {

	private int loyalty;			//The loyalty of pet
	private int shame;				//The shame of pet

	public int Loyalty
	{
		set
		{
			if(value <= 0)
			{
				loyalty = 0;
			}
			else if(value >= 100)
			{
				 loyalty = 100;
			}
			else
			{
				loyalty = value;
			}
		}
		get	
		{
			return loyalty;
		}
	}
	public int Shame
	{
		set
		{
			if(value <= 0)
			{
				shame = 0;
			}
			else if(value >= 100)
			{
				shame = 100;
			}
			else
			{
				shame = value;
			}
		}
		get
		{
			return shame;
		}
	}

	public Pet(string _name,int _gender,string _race,int _level,
				int _force_attack,int _force_defense,int _force_hit,float _force_critical,int _force_probability,
				int _magic_attack,int _magic_defense,int _magic_hit,float _magic_critical,int _magic_probability,
				int _health,int _magic,int _move_speed,int _dodge,int _current_health,int _current_magic,int _loyalty,int _shame)
				:base(_name,_gender,_race,_level,_force_attack,_force_defense,_force_hit,_force_critical,_force_probability,_magic_attack,
				_magic_defense,_magic_hit,_magic_critical,_magic_probability,_health,_magic,_move_speed,_dodge,_current_health,_current_magic)
				{
					Loyalty = _loyalty;
					Shame = _shame;
				}
	
}
