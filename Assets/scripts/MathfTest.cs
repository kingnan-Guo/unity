using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 弧度 转 度
        float r = Mathf.PI / 2.0f;
        // 度 转 弧度
        float degree= r * Mathf.Rad2Deg;
        Debug.Log("弧度：" + r + "度：" + degree);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


// 弧度 与 度 转化
// PI
// 线性插值
// 反三角函数 求角度