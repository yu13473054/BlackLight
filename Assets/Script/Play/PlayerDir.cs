using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Move
}

public class PlayerDir : MonoBehaviour {
    public GameObject mouseHitEffect;
    public float moveSpeed=3;

    bool isTouchDown;
    bool isMove;
    CharacterController chaCtrl;
    RaycastHit hitInfo;
    Vector3 targetPos;
    public PlayerState playerState;

	void Start () {
        playerState = PlayerState.Idle;
		chaCtrl=GetComponent<CharacterController>();
	}
	
	void Update () {
        //Debug.Log("update");
		if (Input.GetMouseButtonDown(0))
		{
            //Debug.Log("GetMouseButtonDown");
            if (hitGround(out hitInfo))
            {
                //显示点击效果
                ShowHitEffect(new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z));
                isTouchDown = true;
            }
            
		}
        else if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("GetMouseButtonUp");
            isTouchDown = false;
        }
		
        if (isTouchDown)
        {
            if (hitGround(out hitInfo))
            {
                LookAtTarget(new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z));
                isMove = true;
                playerState = PlayerState.Move;
            }
        }
        if (isMove)
        {
            LookAtTarget(targetPos);
             Move();
        }
	}

    void Move()
    {
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance > 0.1f)
        {
            chaCtrl.SimpleMove(transform.forward * moveSpeed);
        }
        else
        {
            isMove = false;
            playerState = PlayerState.Idle;
        }

    }

    bool hitGround(out RaycastHit hitInfo)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isCollision = Physics.Raycast(ray, out hitInfo);
        if (isCollision && hitInfo.collider.tag == Tags.ground)
        {
            return true;
        }
        return false;
    }

    void ShowHitEffect(Vector3 hitPos)
    {
        hitPos.y += 0.1f;
        GameObject.Instantiate(mouseHitEffect, hitPos, Quaternion.identity);
    }

    void LookAtTarget(Vector3 target)
    {
        target.y = transform.position.y;

        this.targetPos = target;
        transform.LookAt(target);
    }
}
