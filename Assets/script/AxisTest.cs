using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取 轴 
        // float h = Input.GetAxis("Horizontal");// 水平轴
        // float v = Input.GetAxis("Vertical");// 垂直轴
        // Debug.Log("h:" + h + " v:" + v);

        //  虚拟按钮
        if (Input.GetButtonDown("Jump")){
            Debug.Log("Jump space");
        }
    }
}
