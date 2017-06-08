using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCamera : MonoBehaviour {
	public float speed = 10;

	private float endZ=-20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("test="+Time.deltaTime);
		if(transform.position.z<-20){
			transform.Translate (Vector3.forward*speed*Time.deltaTime);
		}
	}
}
