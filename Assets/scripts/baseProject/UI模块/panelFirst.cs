using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelFirst : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {

        // Button button = GetControl<Button>("Button1 (Legacy)");
        // Debug.Log(button);
        // button.onClick.AddListener(() => {
        //     Debug.Log("Button1");
        // });


        GetControl<Button>("Button1 (Legacy)");


    }

    protected override  void Awake()
    {
        base.Awake();
        Debug.Log(" 子类 自己的 Awake");
    }

    public void initInfo(){
        Debug.Log("initInfo");
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
            case "Button1":
                Debug.Log("Button1");
                break;
            case "Button2":
                Debug.Log("Button2");
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
