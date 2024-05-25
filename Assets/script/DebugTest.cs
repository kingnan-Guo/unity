using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("waring");
        Debug.LogError("error");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(new Vector3(1,0,0), new Vector3(1,1,0), Color.blue);// 直线  起点  终点
        Debug.DrawRay(new Vector3(1,0,0), new Vector3(1,1,0), Color.red);// 射线 起点 射线
    }
}
