using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public float scrollSpeed=5;
    public float minDis = 4;
    public float maxDis = 13;

    Transform playerTrans;
    Vector3 ofstV;//相机和角色的位置偏移
    Vector3 initOfstNormalize;
    private float ofstDis;//相机和角色的距离

	// Use this for initialization
	void Start () {
        playerTrans = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(playerTrans);
        ofstV = transform.position - playerTrans.position;

        ofstDis = ofstV.magnitude;
        initOfstNormalize = ofstV.normalized;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerTrans.position + ofstV;
        ChangeFieldDis();
	}

    void ChangeFieldDis()
    {
        /*
         * velocity：滚轮向前滚动，返回正值（拉近视野）
         *        滚轮向后滚动，返回负值  （拉远视野）
         */
        float velocity = Input.GetAxis("Mouse ScrollWheel");
        if (velocity!=0)
        {
            ofstDis -= velocity * scrollSpeed;
            if (ofstDis<minDis)
            {
                ofstDis = minDis;
            }
            else if(ofstDis>maxDis)
            {
                ofstDis = maxDis;
            }
                ofstV = initOfstNormalize * ofstDis;
            
        }
    }
}
