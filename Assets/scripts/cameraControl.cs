using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float dragSpeed = 10f; // 拖拽速度
    private Vector3 mouseReference; // 记录鼠标位置的变量
    private bool drag = false; // 拖拽状态
 
    void Update()
    {
        // 当左键按下时开始拖拽
        if (Input.GetMouseButtonDown(1))
        {
            drag = true;
            // 记录鼠标位置
            mouseReference = Input.mousePosition;
        }
 
        // 当左键松开时停止拖拽
        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
        }
 
        // 只有在拖拽状态下才更新摄像机位置
        if (drag)
        {
            // 计算鼠标的移动量
            Vector3 mouseOffset = (Vector3)(Input.mousePosition - mouseReference);
            // 移动摄像机
            transform.Translate(mouseOffset.x * dragSpeed * Time.deltaTime, 0, mouseOffset.y * dragSpeed * Time.deltaTime);
            // 更新鼠标参考位置
            mouseReference = Input.mousePosition;
        }
    }
}
