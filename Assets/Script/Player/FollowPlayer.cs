using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float scrollSpeed = 5;
    public float minDis = 4;
    public float maxDis = 13;
    public float rotateSpeed = 3;
    public float minVerticalRotate = 10;
    public float maxVerticalRotate = 60;

    private Transform playerTrans;
    Vector3 ofstV;//相机和角色的位置偏移
    Vector3 initOfstNormalize;
    private float ofstDis;//相机和角色的距离
    bool isRotating;//是否开始旋转视野

    // Use this for initialization
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(playerTrans);
        ofstV = transform.position - playerTrans.position;

        ofstDis = ofstV.magnitude;
        initOfstNormalize = ofstV.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTrans.position + ofstV;
        RotateView();
        ScrollView();

    }
    void RotateView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            //围绕主角水平旋转
            float xValue = Input.GetAxis("Mouse X");
            if (xValue > 0.01f || xValue < -0.01f)
            {
                transform.RotateAround(playerTrans.position, playerTrans.up, rotateSpeed * xValue);
            }
            //围绕主角竖直方向上旋转
            float yValue = Input.GetAxis("Mouse Y");

            if (yValue > 0.01f || yValue < -0.01f)
            {
                Vector3 originPos = transform.position;
                Quaternion originRotate = transform.rotation;//保存原来的旋转角度和坐标
                transform.RotateAround(playerTrans.position, transform.right, -rotateSpeed * yValue);
                //当此时角度达到极限值后，使旋转属性失效
                float rotateX = transform.eulerAngles.x;
                if (rotateX < minVerticalRotate || rotateX > maxVerticalRotate)
                {
                    transform.position = originPos;
                    transform.rotation = originRotate;
                }

                /************************************************************************/
                /*   不能这样写：旋转还会影响到坐标，
                 * 当达到界限时，坐标的改变后，旋转角度可以重新变为另外一个朝向的极限值
                float rotateX = Mathf.Clamp(transform.eulerAngles.x, 10, 80);
                transform.eulerAngles = new Vector3(rotateX, transform.eulerAngles.y, transform.eulerAngles.z);
                 */
                /************************************************************************/
            }

            //旋转后，重新计算镜头和角色的距离向量
            ofstV = transform.position - playerTrans.position;
            initOfstNormalize = ofstV.normalized;
        }
    }
    void ScrollView()
    {
        /*
         * velocity：滚轮向前滚动，返回正值（拉近视野）
         *        滚轮向后滚动，返回负值  （拉远视野）
         */
        float velocity = Input.GetAxis("Mouse ScrollWheel");
        if (velocity != 0)
        {
            ofstDis -= velocity * scrollSpeed;
            ofstDis = Mathf.Clamp(ofstDis, minDis, maxDis);
            //if (ofstDis<minDis)
            //{
            //    ofstDis = minDis;
            //}
            //else if(ofstDis>maxDis)
            //{
            //    ofstDis = maxDis;
            //}
            ofstV = initOfstNormalize * ofstDis;

        }
    }
}
