using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TimeTest");
        
        // 开始到现在所花费的时间
        Debug.Log(Time.time);
        // 时间缩放值
        Debug.Log(Time.timeScale);
        // 固定时间间隔
        Debug.Log(Time.fixedDeltaTime);

    }

    // Update is called once per frame
    // 每一帧 执行一次
    void Update()
    {
        // Time.deltaTime 上一帧到这一振 的时间
        // Debug.Log(Time.deltaTime);
        timer = timer +  Time.deltaTime;
        
        if(timer >  10){
            Debug.Log("大于 " + timer);
        }
    }

    // 每 0.02s 执行一次
    void FixedUpdate(){

    }
    
}
