using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDeviceInfo
{
    // Start is called before the first frame update
    public getDeviceInfo(){
        // MonoManager.getInstance().StartCoroutine(TestIEnumerator());
        EventCenterOptimize.getInstance().AddEventListener<GameObject>("mousePositionPhysics", (res) => {
            Debug.Log("接收到的 楼层 222" + res.name);
        });

    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
