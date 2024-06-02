// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.EventSystems;

// /// <summary>
// /// 模式：不需挂载，单例；
// /// 关系：由“UI管理器_类”初始化；
// /// 功能：对一众UI注册监听事件；
// /// </summary>
// public class 功能_注册监听事件_类
// {
//     private 功能_注册监听事件_类() { }

//     public readonly static 功能_注册监听事件_类 单例 = new 功能_注册监听事件_类();


//     public void 添加一众监听事件()
//     {
//         全部按钮添加监听事件();
//         // 全部提示锚点添加监听事件();
//         // 全部排序项目添加监听事件();
//         // 全部城池名添加监听事件();
//     }

//     /// <summary>
//     /// new将数据放在堆中，节省栈空间
//     /// </summary>
//     private void 全部按钮添加监听事件()
//     {
//         //============================
//         //“行政_按钮”触发：菜单按钮出现或消失
//     //     UI_UI监听事件管理器_类.单例.为UI添加事件(UI_panel管理器_类.单例.panel字典_访问器["行政周期进度条_panel"].GetChild(0), EventTriggerType.PointerClick, new UnityAction<BaseEventData>(UI_监听事件管理器_类.单例.播放动画_菜单按钮出现或消失));
//     //     //“行政_按钮”按下：
//     //     UI_UI监听事件管理器_类.单例.为UI添加事件(UI_panel管理器_类.单例.panel字典_访问器["行政周期进度条_panel"].GetChild(0), EventTriggerType.PointerDown, new UnityAction<BaseEventData>(功能_玩家结束行政周期_类.单例.按下行政按钮));
//     //     //“行政_按钮”松开：
//     //     UI_UI监听事件管理器_类.单例.为UI添加事件(UI_panel管理器_类.单例.panel字典_访问器["行政周期进度条_panel"].GetChild(0), EventTriggerType.PointerUp, new UnityAction<BaseEventData>(功能_玩家结束行政周期_类.单例.抬起行政按钮));

//     //     //“外交菜单按钮”触发： 播放动画_外交菜单展开或收缩
//     //     UI_UI监听事件管理器_类.单例.为UI添加事件(UI_panel管理器_类.单例.panel字典_访问器["菜单_panel"].GetChild(0).GetChild(3), EventTriggerType.PointerClick, new UnityAction<BaseEventData>(UI_监听事件管理器_类.单例.播放动画_外交菜单展开或收缩));
//     //     //“军事菜单按钮”触发： 播放动画_军事菜单展开或收缩
//     //     UI_UI监听事件管理器_类.单例.为UI添加事件(UI_panel管理器_类.单例.panel字典_访问器["菜单_panel"].GetChild(1).GetChild(3), EventTriggerType.PointerClick, new UnityAction<BaseEventData>(UI_监听事件管理器_类.单例.播放动画_军事菜单展开或收缩));
//     //     //“征讨按钮”触发： 播放动画_军事菜单展开或收缩
//     //     UI_UI监听事件管理器_类.单例.为UI添加事件(UI_panel管理器_类.单例.panel字典_访问器["菜单_panel"].GetChild(1).GetChild(2), EventTriggerType.PointerClick, new UnityAction<BaseEventData>(UI_监听事件管理器_类.单例.显示集结界面));
//     //     //“宣战按钮”触发：
//     //    UI_UI监听事件管理器_类.单例.为UI添加事件(UI_panel管理器_类.单例.pan



//     }
// }