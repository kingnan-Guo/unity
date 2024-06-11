using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RoScal : MonoBehaviour {
 
    public float xSpeed = 100;//旋转速度
    public float ySpeed = 100;
    public float yMinLimit = -20;//旋转限制
    public float yMaxLimit = 80;
    public float x = 0.0f;
    public float y = 0.0f;
    public float scroll = 3;
    public float axisraw = 10;
 
    void Start()
    {
        Vector2 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
 
    }
 
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        }
        Ctrl_Cam_Move();              
    }
     //镜头的远离和接近
    private void Ctrl_Cam_Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 p0 = Camera.main.transform.position;
            Vector3 p01 = p0 - Camera.main.transform.right * Input.GetAxisRaw("Mouse X") * axisraw * Time.timeScale;
            Vector3 p03 = p01 - Camera.main.transform.up * Input.GetAxisRaw("Mouse Y") * axisraw * Time.timeScale;
            Camera.main.transform.position = p03;
        }
        else
        {
            float wheel = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * scroll;
            transform.Translate(Vector3.forward * wheel);
        }        
                   
    }
 
    public void LateUpdate()
    {
        y = ClampAngle(y, yMinLimit, yMaxLimit);
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        transform.rotation = rotation;
 
    }
 
    /// <summary>
    /// Y值的限制
    /// </summary>
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
 
        if (angle > 360)
            angle -= 360;
 
        return Mathf.Clamp(angle, min, max);
    }
}