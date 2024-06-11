using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagitCamController : MonoBehaviour
{
 
    // 旋转的目标点
    public Transform target;
    public float distance = 5.0f;

    public Vector3 startRotation;

    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
 
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
 
    public float distanceMin = .5f;
    public float distanceMax = 15f;
    
    float x = 0.0f;
    float y = 0.0f;

    private bool init = false;
 
    // 初始角度设置
    void Start () 
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
 
    }
    void LateUpdate () 
    {
        print("LateUpdate =="+target);
        if (target) 
        {

            if (Input.GetMouseButton (0) || Input.GetAxis ("Mouse ScrollWheel") != 0.0f || !init) {
                x += Input.GetAxis ("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;
 
                //y = ClampAngle (y, yMinLimit, yMaxLimit);

 
                Quaternion rotation = Quaternion.Euler (y + startRotation.x, x + startRotation.y, 0 + startRotation.z);
 
                distance = Mathf.Clamp (distance - Input.GetAxis ("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
 
                RaycastHit hit;
                if (Physics.Linecast (target.position, transform.position, out hit)) {
                    distance -= hit.distance;
                }
                Vector3 negDistance = new Vector3 (0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.position;


                transform.rotation = rotation;
                transform.position = position;
                init = true;
            } 
        }
    }
 
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
