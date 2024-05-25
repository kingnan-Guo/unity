using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Awake(){
        Debug.Log("脚本 Awake");

        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("脚本 start");
        Vector3 v = new Vector3(1,1, 0.5f);
        v = Vector3.zero;// 初始化  为 0 0 0 的结构体
        v = Vector3.right;// 1 0 0
        v.y = 2;
        Vector3 v2 = Vector3.forward;// 0 0 1
        Debug.Log(Vector3.Angle(v, v2));// 夹角
        Debug.Log(Vector3.Distance(v, v2));

        Debug.Log(Vector3.Dot(v, v2));//点乘
        Debug.Log(Vector3.Cross(v, v2));// 叉乘 获取到的是向量
        Debug.Log(Vector3.Lerp(Vector3.zero, Vector3.one, 0.5f));// 插值 在两个 向量之间 做比例计算

        Debug.Log(v.magnitude);// 模长
        Debug.Log(v.normalized);// 规范化向量
    }

    // Update is called once per frame
    void Update()
    {

    }
}
