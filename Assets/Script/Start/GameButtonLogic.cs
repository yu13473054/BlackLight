﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonLogic : MonoBehaviour {

	public void NewGameBtnDeal(){//加载新游戏的按钮的处理
		Debug.Log("NewGameBtnDeal点击了！");
	}

	public void LoadGameBtnDeal(){//重载已经存储的场景的处理
		Debug.Log("LoadGameBtnDeal点击了！");
	}

}
