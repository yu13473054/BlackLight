using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

    PlayerDir playerDir;
    Animation animation;

	// Use this for initialization
	void Start () {
        playerDir = this.GetComponent<PlayerDir>();
        animation = this.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		switch (playerDir.playerState)
		{
		case PlayerState.Idle:
                animation.CrossFade("Idle");
			break;
        case PlayerState.Move:
                animation.CrossFade("Run");
            break;
		}
		
	}
}
