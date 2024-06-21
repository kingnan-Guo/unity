using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functionManagerInheritMono : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        transformPosition transformPosition = new transformPosition();
        MonoManager.getInstance().AddUpdateListener(transformPosition.Update);

        getDeviceInfo getDeviceInfo = new getDeviceInfo();
        MonoManager.getInstance().AddUpdateListener(getDeviceInfo.Update);


        // EventCenter.getInstance().AddEventListener("KeyDown", InputEvent);
        // EventCenter.getInstance().AddEventListener("KeyUp", InputEvent);

        mouseInputMgr.getInstance();
        
        EventCenter.getInstance().AddEventListener("鼠标点击左键", (res) => {
            Debug.Log("鼠标点击左键"+ res);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
