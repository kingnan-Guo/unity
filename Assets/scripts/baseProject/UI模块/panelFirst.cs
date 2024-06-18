using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelFirst : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {

        Button button = GetControl<Button>("Button1 (Legacy)");
        Debug.Log(button);
        button.onClick.AddListener(() => {
            Debug.Log("Button1");
        });

    }

    public void initInfo(){
        Debug.Log("initInfo");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
