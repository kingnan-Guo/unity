using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transfor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 获取位置
        Debug.Log(transform.position);
        Debug.Log(transform.localPosition);// 相对于 父物体的 位置
        // 获取旋转
        Debug.Log(transform.rotation);
        Debug.Log(transform.localRotation);// 相对于 父物体的 旋转

        // 获取 欧拉角；  xyz 分别表示 绕 x y z 轴的旋转角度
        Debug.Log(transform.eulerAngles);

        


        // 获取缩放   缩放 只会相对于 父物体
        Debug.Log(transform.localScale);

        // 物体的 向量
        Debug.Log(transform.forward);// 物体 面向 哪个方向
        Debug.Log(transform.right);// 物体 向右 哪个方向
        Debug.Log(transform.up);// 物体 向上 哪个方向


        // 设置位置
        // transform.position = new Vector3(1, 1, 1);
        // 设置旋转
        // transform.rotation = Quaternion.Euler(0, 0, 0);
        // 设置缩放
        // transform.localScale = new Vector3(1, 1, 1);


        // =========

        // 父子 关系
        // 获取 父物体
        Debug.Log(transform.parent.gameObject);
        // 获取 子物体 个数
        Debug.Log(transform.childCount);
        // 获取 子物体 列表
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)   
        {
            Debug.Log("children[i] =",children[i]);
        }


        // 获取子物体 返回值 是
        Transform trans = transform.Find("childrenCylinder");
        // Debug.Log(trans);
        // 也可以使用 
        trans =  transform.GetChild(0);
        // Debug.Log(trans);

        // 判断 一个物体是否时候 另外一个  物体 的 子物体; trans  是否 是 transform 的子物体 
        bool isChildren = trans.IsChildOf(transform);
        Debug.Log("isChildren = " + isChildren);
        // 获取 子物体 的 索引
  

        // 添加 子物体 并 设置 位置
        // 解除 与 子物体  的 父子 关系
        transform.DetachChildren();


    }

    // Update is called once per frame
    void Update()
    {
        // 将物体 的 forward 朝向 0 0 0 
        // transform.LookAt(Vector3.zero);

        // 旋转  绕着 up轴 旋转 ， 每一帧 旋转一度
        // transform.Rotate(Vector3.up, 1);

        //  绕 某个 物体旋转  ; Vector3.zero 某个物体 ； Vector3.up 无腿的哪个 轴
        // transform.RotateAround(Vector3.zero, Vector3.up, 1);

        // 向 前方 移动 0.1 /s
        // transform.Translate(Vector3.forward * 0.1f);
    }
}
