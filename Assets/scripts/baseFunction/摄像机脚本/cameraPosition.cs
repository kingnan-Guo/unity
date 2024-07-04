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

    private GameObject Cube;
    void Start()
    {
        
        print("cameraPosition ==" + this.gameObject.transform.position);

        camera = GetComponent<Camera>();
        Rotion_Transform = new Vector3(0, 0, 0);
        // camera.transform.LookAt(Rotion_Transform);
        // 创建 cube 
        Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Cube.transform.position = Rotion_Transform;
        Cube.name = "LookAt";

        Cube.GetComponent<Renderer>().material.color = Color.red;

        camera.transform.LookAt(Cube.transform.position);
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
            // moveDir = new Vector3(moveDir.x, 0, moveDir.z);

            // 设置摄像机的旋转
            // if (Input.GetKey(KeyCode.Mouse2)) {
            //     // Debug.Log(transform.forward);
            //     Debug.Log("moveDir ==" + moveDir);
            // }
            float moveSpeed = 15f;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            Rotion_Transform += moveDir * moveSpeed * Time.deltaTime;

            Cube.transform.position = Rotion_Transform;





            if (Input.GetMouseButton(2)){
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                // 横向平移
                MoveCameraSideways(mouseX);

                // 纵向平移，若相机垂直地面则向前平移
                MoveCameraUpwards(mouseY);
            }



        }




        //  if (Input.GetMouseButtonDown(2))
        // {
        //     // 开始拖动操作
        //     Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        //     Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //     // transform.position = objPosition;

        //     Debug.Log("GetMouseButtonDown =="+ mousePosition);
        // }
 
        // // 检查鼠标中键是否持续按下
        // if (Input.GetMouseButton(2))
        // {
        //     // 正在拖动
        //     // Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        //     // Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //     // transform.position = objPosition;

        //     Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

        //     Debug.Log("GetMouseButton mousePosition =="+ mousePosition);
        // }
 
        // // 检查鼠标中键是否松开
        // if (Input.GetMouseButtonUp(2))
        // {
        //     Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

        //     Debug.Log("GetMouseButtonUp mousePosition =="+ mousePosition);
        // }


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


    // 更新相机的横向平移
    private void MoveCameraSideways(float mouseX)
    {
        // transform.Translate(Vector3.right * 100 * Time.deltaTime * -mouseX);

        // Cube.transform.position = Rotion_Transform;
        Cube.transform.Translate(Vector3.right * 100 * Time.deltaTime * -mouseX);
        // Cube.transform.position = transform.position;

        Debug.Log("Cube.transform =="+ Cube.transform.position);

        // Debug.Log("transform =="+ transform.position);

        // Vector3 data = Vector3.right * 100 * Time.deltaTime * - mouseX;
        // // Debug.Log("transform =="+ (Vector3.right * 100 * Time.deltaTime * - mouseX));
        // Rotion_Transform += new Vector3(data.x, 0, data.z);
        // // Rotion_Transform = new Vector3(Rotion_Transform.x + transform.position.x, 0, Rotion_Transform.z + transform.position.z);
        // Debug.Log("Rotion_Transform =="+ Rotion_Transform);

    }

    // 更新相机的纵向平移
    private void MoveCameraUpwards(float mouseY)
    {
        // transform.Translate(Vector3.up * 100 * Time.deltaTime * -mouseY);
        Cube.transform.Translate(Vector3.up * 100 * Time.deltaTime * -mouseY);
        // Debug.Log("transform =="+ transform.position);

        // Cube.transform.Translate(Vector3.up * 100 * Time.deltaTime * -mouseY);

        // Debug.Log("Cube.transform =="+ Cube.transform.position);
        // Cube.transform.position = transform.position;
        // Vector3 data = Vector3.up * 100 * Time.deltaTime * - mouseY;
        // Rotion_Transform += new Vector3(data.x, 0, data.z);
        // // Debug.Log("transform =="+ (Vector3.up * 100 * Time.deltaTime * -mouseY));
        // // Rotion_Transform = new Vector3(Rotion_Transform.x + transform.position.x, 0, Rotion_Transform.z + transform.position.z);
        // Debug.Log("Rotion_Transform =="+ Rotion_Transform);

    }

    


}
