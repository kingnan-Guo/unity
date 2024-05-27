using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  鼠标  点击; 0  表示鼠标左键 ；1  表示鼠标右键； 2  表示鼠标中键
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("鼠标左键点击");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("鼠标右键点击");
        }

        // 按住 鼠标
        if (Input.GetMouseButton(0))
        {
            Debug.Log("按住鼠标左键");
        }

        // 释放 鼠标
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("释放鼠标左键");
        }

        // 鼠标 移动
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Debug.Log("鼠标移动");
        }
        


        //  按钮 按下
        if (Input.GetKeyDown(KeyCode.W)){
            Debug.Log("W 按下");
        }

        //  按钮 抬起  
        if (Input.GetKeyUp(KeyCode.W)){
            Debug.Log("W 抬起");

        }

        //  按钮 按下 抬起  
        if (Input.GetKey(KeyCode.W)){
            Debug.Log("W 持续 ");
        }
        // 按住 按钮
        // if (Input.GetKey(KeyCode.W)){
            
        // }
    }
}
