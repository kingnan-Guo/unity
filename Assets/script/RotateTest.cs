using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 旋转 ： 欧拉角 
        Vector3 rotate = new Vector3(0, 30, 0);// 延 y 轴 旋转 30 度
        // 旋转 ： 四元数 四位空间的 高阶复数
        Quaternion quaternion = Quaternion.identity;// 提供 x y  z w ; identity 无旋转
        quaternion =  Quaternion.Euler(rotate);// 欧拉角转换成  四元数
        // 四元数 转换成  欧拉角
        rotate = quaternion.eulerAngles;
        Debug.Log(rotate);
        // 看向 一个物体
        quaternion = Quaternion.LookRotation(new Vector3(0,0,0));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
