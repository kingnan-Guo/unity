using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class JsonDataManagerDemo: baseManager<JsonDataManagerDemo>
{

    public JsonDataManagerDemo(){
        MonoManager.getInstance().StartCoroutine(loadModel());

        // deviceModel.getInstance().init("json/test", (res) =>{
        //     EventCenterOptimize.getInstance().EventTrigger<Dictionary<string, object>>("DeviceInfoDictionary", res);
        // });


    }

    IEnumerator loadModel(){

        deviceModel.getInstance().init("json/test", (res) =>{
            // Debug.Log("res: " + res.Count);
            EventCenterOptimize.getInstance().EventTrigger<Dictionary<string, object>>("DeviceInfoDictionary", res);
        });
        yield return new WaitForSeconds(1);
        Debug.Log("MonoTest IEnumerator test");
    }


    public void Update()
    {
        
    }
}
