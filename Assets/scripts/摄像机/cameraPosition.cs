using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
//摄像机操作   
//删减版   在实际的使用中可能会有限制的需求  比如最大远离多少  最近距离多少   不能旋转到地面以下等
public class cameraPosition : MonoBehaviour
{
    private Transform CenObj;//围绕的物体
    private Vector3 Rotion_Transform;
    private new Camera camera;
    void Start()
    {
        
        print("cameraPosition ==" + this.gameObject.transform.position);

        camera = GetComponent<Camera>();
        Rotion_Transform = new Vector3(0, 0, 0);
        camera.transform.LookAt(Rotion_Transform);
        // Debug.Log("Rotion_Transform ==" + Rotion_Transform);
    }
    void Update()
    {
        Ctrl_Cam_Move();
        Cam_Ctrl_Rotation();

        // Input.GetKey(KeyCode.Mouse2) ||
        if ( true)
        {
            Vector3 inputDir = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                inputDir.z = +1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputDir.z = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputDir.x = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputDir.x = +1f;
            }
            // 设置摄像机的旋转
            // CenObj.rotation = Quaternion.Euler(CenObj.rotation.eulerAngles.x, CenObj.rotation.eulerAngles.y, 0);
            Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
            moveDir = new Vector3(moveDir.x, 0, moveDir.z);

            // 设置摄像机的旋转
            // if (Input.GetKey(KeyCode.Mouse2)) {
            //     // Debug.Log(transform.forward);
            //     Debug.Log("moveDir ==" + moveDir);
            // }
            float moveSpeed = 20f;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            Rotion_Transform += moveDir * moveSpeed * Time.deltaTime;
        }


    }
    //镜头的远离和接近
    public void Ctrl_Cam_Move()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Translate(Vector3.forward * 1f);//速度可调  自行调整
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Translate(Vector3.forward * -1f);//速度可调  自行调整
        }
    }
    //摄像机的旋转
    public void Cam_Ctrl_Rotation()
    {
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.RotateAround(Rotion_Transform, Vector3.up, mouse_x * 20);
            transform.RotateAround(Rotion_Transform, transform.right, mouse_y * 20);
        }
    }

}
