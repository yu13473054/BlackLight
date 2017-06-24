using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour {
    public GameObject mouseHitEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
            Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollision = Physics.Raycast(ray, out hitInfo);
            Debug.Log(isCollision);
            if (isCollision && hitInfo.collider.tag==Tags.ground)
            {
                //显示点击效果
                ShowHitEffect(hitInfo.point);
            }
            
		}
		
	}

    void ShowHitEffect(Vector3 hitPos)
    {
        hitPos.y += 0.1f;
        GameObject.Instantiate(mouseHitEffect, hitPos, Quaternion.identity);
    }
}
