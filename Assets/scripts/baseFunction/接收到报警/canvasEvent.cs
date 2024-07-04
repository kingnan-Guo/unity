using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class canvasEvent : BasePanel
{
    // Start is called before the first frame update
    
    // Start is called before the first frame update

    protected override  void Awake()
    {
        base.Awake();
        Debug.Log(" 子类 自己的 Awake");
    }

    void Start()
    {
        // UIManager.AddCustomEventListener(GetControl<Button>("alarmButton"), EventTriggerType.PointerEnter, (data) => {
        //     Debug.Log("alarmButton PointerEnter");
        // });

    }

    // 重写 show
    public override void Show()
    {
        base.Show();
        // 显示面板时 想要执行的逻辑， 这个函数 在  UI 管理器 中会自动  帮我们 调用
        // 只要 重写 就会 执行 以下  逻辑

        Debug.Log("public override void Show");

    }

    protected override void OnClick(string buttonMame)
    {
        base.OnClick(buttonMame);
        // 重写 按钮点击事件
        // 只要 重写 就会 执行 以下  逻辑
        Debug.Log("public override void OnClick(string name) = "+ buttonMame);
        switch (buttonMame)
        {
            case "alarmButton2":
                // JsonDataManager.getInstance();
                deviceModel.getInstance().updateDeviceInfo("123321123321123$2$2$2", "deviceStatus", "1");
                break;
            case "alarmButton1":
                // JsonDataManager.getInstance();
                deviceModel.getInstance().updateDeviceInfo("123321123321123$1$1$1", "deviceStatus", "1");
                break;
            case "changeButton":
                // JsonDataManager.getInstance();
                deviceModel.getInstance().updateDeviceInfo("123321123321123$1$1$1", "deviceStatus", "5");
                break;

            case "backBtn":
                Debug.Log("backBtn");
                break;
            default:
                break;
        }
    }


    protected override void onValueChanged(string name, bool value){
        base.onValueChanged(name, value);

        Debug.Log("public override void onValueChanged(string name) = "+ name + " =" + value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
