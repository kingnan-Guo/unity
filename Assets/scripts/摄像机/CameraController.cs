using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //默认移动速度和加速
    public float speedNormal = 5f, speedFast = 20f;
    //旋转速度
    public float mouseSensX = 2f;
    public float mouseSensY = 2f;
    float rotY;
    //移动速度
    float moveSpeed = 5;
    //推进速度
    float zoomSpeed = 20;
    //相机
    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        MouseDisplayController(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MouseDisplayController(true);
        }
        CameraZoom();
        CameraAngle();
        CameraMovement();
    }
    /// <summary>
    /// 按下鼠标右键拖动调整角度
    /// </summary>
    void CameraAngle()
    {
        if (Input.GetMouseButton(1))
        {
            float rotX = transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * mouseSensX);
            rotY += Input.GetAxis("Mouse Y") * mouseSensY;
            rotY = Mathf.Clamp(rotY, -80f, 80f);
            transform.localEulerAngles = new Vector3(-rotY, rotX, 0f);
            MouseDisplayController(false);
        }
    }

    /// <summary>
    /// 相机移动,WASD控制前后左右
    /// </summary>
    void CameraMovement()
    {

        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        if (forward != 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift)) moveSpeed = speedFast;
            else moveSpeed = speedNormal;
            Vector3 vect = new Vector3(0f, 0f, forward * moveSpeed * Time.deltaTime);
            transform.localPosition += transform.localRotation * vect;
        }
        if (side != 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift)) moveSpeed = speedFast;
            else moveSpeed = speedNormal;
            Vector3 vect = new Vector3(side * moveSpeed * Time.deltaTime, 0f, 0f);
            transform.localPosition += transform.localRotation * vect;
        }
    }
    void CameraZoom()
    {
        // 获取鼠标滚轮的输入
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        // 计算相机的新fieldOfView
        float newFOV = cam.fieldOfView - scrollInput * zoomSpeed;
        // 限制相机的fieldOfView范围
        newFOV = Mathf.Clamp(newFOV, 10, 120);
        // 更新相机的fieldOfView
        cam.fieldOfView = newFOV;



    }
    //控制鼠标显示和隐藏
    void MouseDisplayController(bool Value)
    {
        Cursor.visible = Value;
    }

}
