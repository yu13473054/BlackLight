using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressLogic : MonoBehaviour {
	public float pressAvailableTime;
	public Transform btnContainer;

	private bool isPress;

	// Use this for initialization
	void Start () {
//		pressAvailableTime = 4;
//		btnContainer = this.transform.parent.Find ("Button Container").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time>pressAvailableTime && !isPress && Input.anyKey) {
			ShowBtnContainer ();
		}
	}

	void ShowBtnContainer(){
		btnContainer.gameObject.SetActive (true);
		this.gameObject.SetActive (false);
		isPress = false;
	}
}
