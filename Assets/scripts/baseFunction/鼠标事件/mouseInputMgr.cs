using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mouseInputMgr : baseManager<mouseInputMgr>
{
    // Start is called before the first frame update
    public static bool isStart = false;
    public mouseInputMgr(){
        //初始化
        MonoManager.getInstance().AddUpdateListener(myUpdate);
    }


    /// <summary>
    /// 是否开启  输入检测
    /// </summary>
    /// <param name=""></param>
    public void StartOrEndCheck(bool isOpen){
        isStart = isOpen;
    }


    /// <summary>
    /// 检测按键
    /// 1.按下
    /// 2.弹起
    /// </summary>
    /// <param name="keyCode"></param>
    public void checkedKeyCode(){


        // Debug.Log("按下 = "+keyCode);


        // EventCenter.getInstance().EventTrigger("KeyDown", keyCode);

        // Debug.Log("弹起 = "+keyCode);
        // EventCenter.getInstance().EventTrigger("KeyUp", keyCode);
        if(Input.GetMouseButton(0)){
            EventCenter.getInstance().EventTrigger("鼠标点击左键", Input.mousePosition);
        }

        if(Input.GetMouseButton(1)){
            EventCenter.getInstance().EventTrigger("鼠标点击右键", Input.mousePosition);
        }



        // Debug.Log(" 鼠标位置 == "+ Input.mousePosition);
        // if(Input.GetKeyDown(keyCode)){
        //     Debug.Log("按下 = "+keyCode);
        //     EventCenter.getInstance().EventTrigger("KeyDown", keyCode);
        // }

        // if(Input.GetKeyUp(keyCode)){
        //     Debug.Log("弹起 = "+keyCode);
        //     EventCenter.getInstance().EventTrigger("KeyUp", keyCode);
        // }
    }

    private void myUpdate(){

        // Debug.Log("鼠标检测");
        // if(!isStart){
        //     return;
        // }
        // checkedKeyCode(KeyCode.W);
        // checkedKeyCode(KeyCode.S);
        // checkedKeyCode(KeyCode.A);
        // checkedKeyCode(KeyCode.D);


        // checkedKeyCode(MouseButton.Left);
        // checkedKeyCode(MouseButton.Left);

        checkedKeyCode();

    }
}
