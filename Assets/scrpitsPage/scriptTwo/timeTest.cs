using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeTest : MonoBehaviour
{

    
    float fixed_timer = 0.03f;
    float now_timer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.now_timer += Time.deltaTime;
        while (this.now_timer >= this.fixed_timer)
        {
            this.fixed_upDate();
            this.now_timer -= this.fixed_timer;
        }
    }
    // 0.02 执行一次
    void FixedUpdate(){
        // Debug.Log(Time.fixedDeltaTime);
    }

    // FixedUpdate 原理
    // 这里 模拟的 FixedUpdate 并不是  固定时间 调用一次，而是 要在 60 FPS 0.16s 30FPS 0.32s 切换的情况下，60 调用一次 ， 30 就会 调用两次
    void fixed_upDate(){
        Debug.Log(this.fixed_timer);
    }

    // 表示 这里可以 绘制 GUI 的元素 到 屏幕上
    // 通常 使用 UGUI NGUI 来做 GUI
    void OnGUI(){
        Debug.Log("OnGUI");// 插入 绘制 GUI 的代码
    }

    //保证 所有的组件的 update 都被调完 后
    void LateUpdate(){
        Debug.Log("LateUpdate");
    }
    
}
