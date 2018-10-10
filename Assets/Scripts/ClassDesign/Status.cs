//This is for different status
//By Nature
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
	Dizzy,
	BloodDropping,
	Slow
};

public class DizzyStatus
{
	private int continuous_time;		//The status continuous time

	public DizzyStatus(int _continuous_time)
	{
		continuous_time = _continuous_time;
	}

	public IEnumerator StartStatus(Role customer) 
	{
		customer.role_status.Add(Status.Dizzy);
		//Dizzy
		yield return new WaitForSeconds(continuous_time);
		customer.role_status.Remove(Status.Dizzy);
	}
}

public class BloodDroppingStatus
{
	private int losingNumPerTime;		//The losing num per time
	private int continuous_time;		//The status continuous time

	public BloodDroppingStatus(int _losingNumPerTime,int _continuous_time)
	{
		losingNumPerTime = _losingNumPerTime;
		continuous_time = _continuous_time;
	}

	public IEnumerator StartStatus(Role customer) 
	{
		customer.role_status.Add(Status.BloodDropping);
		for(int tmp = 1;tmp <= continuous_time;tmp++)
		{
			yield return new WaitForSeconds(1.0f);
			customer.Current_health -= losingNumPerTime;
		}
		customer.role_status.Remove(Status.BloodDropping);
	}
}

public class SlowStatus
{
	private int continuous_time;		//The status continuous time
	private int slow_num;				//The slow num of speed

	public SlowStatus(int _slow_nunm,int _continuous_time)
	{
		slow_num = _slow_nunm;
		continuous_time = _continuous_time;
	}

	public IEnumerator StartStatus(Role customer) 
	{
		customer.role_status.Add(Status.Slow);
		customer.Move_speed -= slow_num;
		yield return new WaitForSeconds(continuous_time);
		customer.Move_speed += slow_num;
		customer.role_status.Remove(Status.Slow);
	}
}