using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
// /// <summary>
// /// 模式：不需挂载，单例；
// /// 关系：被“UI管理器_类”初始化；
// /// 功能： 调用“功能_注册监听事件_类”实现事件的注册；
// /// </summary>
// public class UI_UI监听事件管理器_类
// {
//     private UI_UI监听事件管理器_类() { 
//         初始化();
//     }


//     public readonly static UI_UI监听事件管理器_类 单例 = new UI_UI监听事件管理器_类();

//     public void 初始化()
//     {
//         // 功能_注册监听事件_类.单例.添加一众监听事件();

//         // new UnityAction<BaseEventData>(悬入耐久) 要执行 函数
//         UI_UI监听事件管理器_类.单例.为UI添加事件(耐久_Image.transform, EventTriggerType.PointerEnter, new UnityAction<BaseEventData>(要执行的函数));
//     }


//     /// <summary>
//     /// 动态添加接口事件
//     /// </summary>
//     public void 为UI添加事件(Transform 目标UI_Transform, EventTriggerType 监听事件类型_枚举, UnityAction<BaseEventData> 待执行函数)
//     {
//         //获取事件系统
//         EventTrigger 事件触发器_组件 = 目标UI_Transform.gameObject.GetComponent<EventTrigger>();

//         //不存在则动态添加
//         if (事件触发器_组件 == null)
//         {
//             事件触发器_组件 = 目标UI_Transform.gameObject.AddComponent<EventTrigger>();
//         }

//         //事件实体
//         EventTrigger.Entry 事件实体 = new EventTrigger.Entry();

//         //事件类型   eventID  事件类型
//         事件实体.eventID = 监听事件类型_枚举;

//         //事件回调
//         事件实体.callback = new EventTrigger.TriggerEvent();

//         //添加回调函数
//         事件实体.callback.AddListener(待执行函数);

//         //监听事件
//         事件触发器_组件.triggers.Add(事件实体);
//     }


// }





// // 1

// // private UI_UI监听事件管理器_类() { 
// //     初始化();
// // }


// // public readonly static UI_UI监听事件管理器_类 单例 = new UI_UI监听事件管理器_类();


// // 2

// // public static UI_UI监听事件管理器_类 单例 { get; private set; }

// // private void Awake()
// // {
// //     单例 = this;
// //     初始化();
// // }



// // ===========


// //  public void 悬入谏言信息条目_圆光术(BaseEventData 基础事件信息)
// //     {

// //         //（1）找到对应的谏言实例：
// //         PointerEventData 鼠标事件_PointerEventData = (PointerEventData)基础事件信息;
// //         谏言_枚举 谏言_枚举 = 功能_字符串转枚举_类.单例.谏言字符串转谏言_枚举(鼠标事件_PointerEventData.pointerEnter.transform.name);


// //         //（3）显示谏言提示框：
// //         UI_谏言提示框_panel管理器_类.单例.显示谏言提示框(谏言字典_类.单例.谏言字典[谏言_枚举]);
// //     }



