using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Ray ray = GetComponent<Ray>();
        // 创建一个射线
        // Ray ray = new Ray(Vector3.zero, Vector3.up);// c从 0 0  向上的射线
        // // 从摄像机 发出的射线 ; Input.mousePosition :  鼠标暗道的点，
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


    }

    // Update is called once per frame
    void Update()
    {
        // 按下鼠标左键 发射 射线
        if(Input.GetMouseButtonDown(0)){
            // 从摄像机 发出的射线 ; Input.mousePosition :  鼠标暗道的点，
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 判断 是否碰到物体； 物体上必须要有碰撞 组件
            //  声明 一个碰撞信息类
            RaycastHit hit;
            // 碰撞检测 ； 返回值代表 是否产生碰撞;  out hit 是 C# 的 输出方式； 执行完成你后  hit 里 包含 碰撞到的信息
            bool res = Physics.Raycast(ray, out hit);
            if (res)
            {
                Debug.Log(hit.point);
                transform.position = hit.point;
            }


             // 多物体检测 ;  100 检测距离；1<<10 只检测第 10 个图层
            //  RaycastHit[] hits = Physics.RaycastAll(ray, 100, 1<<10);

        }


       
        
    }
}
