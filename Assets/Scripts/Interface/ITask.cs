﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITask{
	void CompleteTask(Player tasker,Reward reward);
}
