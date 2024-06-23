using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformPosition
{

    public transformPosition(){
        // MonoManager.getInstance().StartCoroutine(TestIEnumerator());
        EventCenterOptimize.getInstance().AddEventListener<GameObject>("mousePositionPhysics", (res) => {
            Debug.Log("接收到的 楼层" + res.name);
        });
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
