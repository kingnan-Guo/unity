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
        r = degree * Mathf.Deg2Rad;
        Debug.Log("弧度：" + r + "度：" + degree);
        // 线性插值
        float a = Mathf.Lerp(0, 100, 0.5f);
        Debug.Log("插值：" + a);

        // 反三角函数 求角度
        float b = Mathf.Acos(0.5f);
        Debug.Log("反三角函数：" + b);
        float c = Mathf.Sin(b);
        Debug.Log("反三角函数：" + c);
        float d = Mathf.Cos(b);
        Debug.Log("反三角函数：" + d);

        float x1 =1;
        float x2 = 2;
        float y1 = 1;

        float y2 = 2;
        r = Mathf.Atan2(y2 - y1, x2 - x1);
        Debug.Log("两点间角度：" + r);

        degree = r * Mathf.Rad2Deg;
        Debug.Log("两点间角度：" + degree);
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