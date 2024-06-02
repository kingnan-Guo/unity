using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class Multithreading : MonoBehaviour
{

    public void OnSelectDelegate(BaseEventData data)
    {
        Debug.Log("Onsubimt");
        
    }
    void Start()
    {

        EventTrigger 事件触发器_组件 = this.gameObject.GetComponent<EventTrigger>();
        //不存在则动态添加
        if (事件触发器_组件 == null)
        {
            事件触发器_组件 = this.gameObject.AddComponent<EventTrigger>();
        }
        Debug.Log("事件触发器_组件 = " + 事件触发器_组件);
        //事件实体
        EventTrigger.Entry 事件实体 = new EventTrigger.Entry();

        //事件类型   eventID  事件类型
        事件实体.eventID = EventTriggerType.PointerClick;

        //事件回调
        事件实体.callback = new EventTrigger.TriggerEvent();

        //添加回调函数
        事件实体.callback.AddListener(new UnityAction<BaseEventData>(OnSelectDelegate));

        //监听事件
        事件触发器_组件.triggers.Add(事件实体);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// C#多线程示例

//多线程 是 每一个 内核都有 对应 的虚拟内存，二进制代码 放到虚拟内存里；
//线程 是 os 调度 的 最小单位；是 让cpu 独立调度 最小单位
// app -》 进程 -》 第一个线程；
//             -》 第二个线程；
//             -》 第三个线程；


// 线程 与 线程之间