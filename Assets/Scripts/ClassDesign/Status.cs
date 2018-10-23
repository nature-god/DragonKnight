//This is for different status
//By Nature
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum status
{
	Dizzy = 0,
	BloodDropping = 1,
	Slow = 2,
	ForceAttackStronger = 3,
	ForceDefenseStronger = 4,
	ForceHitStronger = 5,
	MagicAttackStronger = 6,
	MagicDefenseStronger = 7,
	MagicHitStronger = 8,
	BloodAdding = 9,
	MagicAdding = 10
};

public class Status
{
	protected int continuous_time;		//The status continuous time
	public Status(int _continuous_time)
	{
		continuous_time = _continuous_time;
	}
}

//Status Pool for not need to Instantiate too many objects
//Emmm I feel this situation is not good for pool.....
#region Not suitable
public class StatusPool
{
	private List<Status> allStatus;

	private static StatusPool instance;
	public static StatusPool Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new StatusPool();
			}
			return instance;
		}
	}

	private StatusPool()
	{	
		DizzyStatus dizzyStatus = new DizzyStatus(1);
		BloodDroppingStatus bloodDroppingStatus = new BloodDroppingStatus(1,1);
		SlowStatus slowStatus = new SlowStatus(1,1);
		ForceAttackStrongerStatus forceAttackStrongerStatus = new ForceAttackStrongerStatus(1,1);

		allStatus.Add(dizzyStatus);
		allStatus.Add(bloodDroppingStatus);
		allStatus.Add(slowStatus);
		allStatus.Add(forceAttackStrongerStatus);
	}

	public Status GetPoolObject(status tmp)
	{
		switch (tmp)
		{
			case status.Dizzy:
			{
				return Instance.allStatus[0];
			}
			case status.BloodDropping:
			{
				return Instance.allStatus[1];
			}
			case status.Slow:
			{
				return Instance.allStatus[2];
			}
			case status.ForceAttackStronger:
			{
				return Instance.allStatus[3];
			}
			default:
			{
				return null;
			}
		}
	}
}
#endregion

public class DizzyStatus : Status,IStatus
{
	public DizzyStatus(int _continuous_time) : base(_continuous_time)
	{

	}

	public IEnumerator StartStatus(Role customer) 
	{
		customer.role_status.Add(status.Dizzy);
		//Dizzy
		yield return new WaitForSeconds(continuous_time);
		customer.role_status.Remove(status.Dizzy);
	}

}

public class BloodDroppingStatus : Status,IStatus
{
	private int losingNumPerTime;		//The losing num per time

	public BloodDroppingStatus(int _losingNumPerTime,int _continuous_time):base(_continuous_time)
	{
		losingNumPerTime = _losingNumPerTime;
	}

	public IEnumerator StartStatus(Role customer) 
	{
		customer.role_status.Add(status.BloodDropping);
		for(int tmp = 1;tmp <= continuous_time;tmp++)
		{
			yield return new WaitForSeconds(1.0f);
			customer.Current_health -= losingNumPerTime;
		}
		customer.role_status.Remove(status.BloodDropping);
	}
}

public class BloodAddingStatus : Status,IStatus
{
	private int addingNumPerTime;		//The losing num per time

	public BloodAddingStatus(int _addingNumPerTime,int _continuous_time):base(_continuous_time)
	{
		addingNumPerTime = _addingNumPerTime;
	}

	public IEnumerator StartStatus(Role customer) 
	{
		customer.role_status.Add(status.BloodAdding);
		for(int tmp = 1;tmp <= continuous_time;tmp++)
		{
			yield return new WaitForSeconds(1.0f);
			customer.Current_health += addingNumPerTime;
		}
		customer.role_status.Remove(status.BloodAdding);
	}
}

public class MagicAddingStatus : Status,IStatus
{
	private int addingNumPerTime;		//The losing num per time

	public MagicAddingStatus(int _addingNumPerTime,int _continuous_time):base(_continuous_time)
	{
		addingNumPerTime = _addingNumPerTime;
	}

	public IEnumerator StartStatus(Role customer) 
	{
		customer.role_status.Add(status.MagicAdding);
		for(int tmp = 1;tmp <= continuous_time;tmp++)
		{
			yield return new WaitForSeconds(1.0f);
			customer.Current_magic += addingNumPerTime;
		}
		customer.role_status.Remove(status.MagicAdding);
	}
}

public class SlowStatus : Status,IStatus
{
	private int slow_num;				//The slow num of speed

	public SlowStatus(int _slow_nunm,int _continuous_time):base(_continuous_time)
	{
		slow_num = _slow_nunm;
	}

	public IEnumerator StartStatus(Role customer) 
	{
		customer.role_status.Add(status.Slow);
		customer.Move_speed -= slow_num;
		yield return new WaitForSeconds(continuous_time);
		customer.Move_speed += slow_num;
		customer.role_status.Remove(status.Slow);
	}
}

public class ForceAttackStrongerStatus : Status,IStatus
{
	private int stronger_num;

	public ForceAttackStrongerStatus(int _stronger_num,int _continuous_time):base(_continuous_time)
	{
		stronger_num = _stronger_num;
	}

	public IEnumerator StartStatus(Role customer)
	{
		customer.role_status.Add(status.ForceAttackStronger);
		customer.Force_attack += stronger_num;
		yield return new WaitForSeconds(continuous_time);
		customer.Force_attack -= stronger_num;
		customer.role_status.Remove(status.ForceAttackStronger);
	}
}

public class ForceDefenseStrongerStatus : Status,IStatus
{
	private int stronger_num;

	public ForceDefenseStrongerStatus(int _stronger_num,int _continuous_time):base(_continuous_time)
	{
		stronger_num = _stronger_num;
	}

	public IEnumerator StartStatus(Role customer)
	{
		customer.role_status.Add(status.ForceDefenseStronger);
		customer.Force_defense += stronger_num;
		yield return new WaitForSeconds(continuous_time);
		customer.Force_defense -= stronger_num;
		customer.role_status.Remove(status.ForceDefenseStronger);
	}
}

public class ForceHitStrongerStatus : Status,IStatus
{
	private int stronger_num;

	public ForceHitStrongerStatus(int _stronger_num,int _continuous_time):base(_continuous_time)
	{
		stronger_num = _stronger_num;
	}

	public IEnumerator StartStatus(Role customer)
	{
		customer.role_status.Add(status.ForceHitStronger);
		customer.Force_hit += stronger_num;
		yield return new WaitForSeconds(continuous_time);
		customer.Force_hit -= stronger_num;
		customer.role_status.Remove(status.ForceHitStronger);
	}
}


public class MagicAttackStrongerStatus : Status,IStatus
{
	private int stronger_num;

	public MagicAttackStrongerStatus(int _stronger_num,int _continuous_time):base(_continuous_time)
	{
		stronger_num = _stronger_num;
	}

	public IEnumerator StartStatus(Role customer)
	{
		customer.role_status.Add(status.MagicAttackStronger);
		customer.Magic_attack += stronger_num;
		yield return new WaitForSeconds(continuous_time);
		customer.Magic_attack -= stronger_num;
		customer.role_status.Remove(status.MagicAttackStronger);
	}
}

public class MagicDefenseStrongerStatus : Status,IStatus
{
	private int stronger_num;

	public MagicDefenseStrongerStatus(int _stronger_num,int _continuous_time):base(_continuous_time)
	{
		stronger_num = _stronger_num;
	}

	public IEnumerator StartStatus(Role customer)
	{
		customer.role_status.Add(status.MagicDefenseStronger);
		customer.Magic_defense += stronger_num;
		yield return new WaitForSeconds(continuous_time);
		customer.Magic_defense -= stronger_num;
		customer.role_status.Remove(status.MagicDefenseStronger);
	}
}

public class MagicHitStrongerStatus : Status,IStatus
{
	private int stronger_num;

	public MagicHitStrongerStatus(int _stronger_num,int _continuous_time):base(_continuous_time)
	{
		stronger_num = _stronger_num;
	}

	public IEnumerator StartStatus(Role customer)
	{
		customer.role_status.Add(status.MagicHitStronger);
		customer.Magic_hit += stronger_num;
		yield return new WaitForSeconds(continuous_time);
		customer.Magic_hit -= stronger_num;
		customer.role_status.Remove(status.MagicHitStronger);
	}
}