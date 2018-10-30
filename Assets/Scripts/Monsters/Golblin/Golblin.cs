using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golblin : Role {

	public Golblin(string _name,int _gender,string _race,int _level,
				int _force_attack,int _force_defense,int _force_hit,float _force_critical,int _force_probability,
				int _magic_attack,int _magic_defense,int _magic_hit,float _magic_critical,int _magic_probability,
				int _health,int _magic,int _move_speed,int _dodge,int _current_health,int _current_magic)
				:base(_name,_gender,_race,_level,_force_attack,_force_defense,_force_hit,_force_critical,_force_probability,_magic_attack,
				_magic_defense,_magic_hit,_magic_critical,_magic_probability,_health,_magic,_move_speed,_dodge,_current_health,_current_magic)
				{
					//ClawHit clawHit = new ClawHit("爪击",2,0,"使用锋利的爪子进行攻击",1);
					//ResumeSelf resumeSelf = new ResumeSelf("回复术",10,5,5,"简单的回复技巧");
					//this.role_skills.Add(clawHit);
					//this.role_skills.Add(resumeSelf);
				}
}
