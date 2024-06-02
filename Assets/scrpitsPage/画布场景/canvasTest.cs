using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class canvasTest : MonoBehaviour
{

    public void OnSelectDelegate(BaseEventData data)
    {
        Debug.Log("Onsubimt");
        
    }
    // Start is called before the first frame update
    void Start()
    {

        //EventTriggerType.PointerEnter, new UnityAction<BaseEventData>(要执行的函数)


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
