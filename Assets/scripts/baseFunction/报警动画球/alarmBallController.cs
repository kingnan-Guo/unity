using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class alarmBallController
{
    

    Dictionary<string, object> alarmBallDic = new Dictionary<string, object>();
    Dictionary<string, string> pathDictionary = new Dictionary<string, string>();

    public alarmBallController(){
        pathDictionary.Add("alarmBall", "Prefab/3d/alarmBall");
        EventCenterOptimize.getInstance().AddEventListener<eventContent>("upDateDeiveInfo", (res) => {
            // upDateData<eventContent>(res);

            Debug.Log("报警动画球"+ res);



            upDateData<eventContent>(res);
            
        });
    }



   public void upDateData<T>(T data) where T : eventContent
   {
        deviceEventType type = data.eventType;
        switch (type)
        {
            case deviceEventType.changeDeviceInfo:
                upDateInfo(data.imei);
                break;
            case deviceEventType.addDevice:

                break;
            default:
                break;
        }
   }

    public void upDateInfo(string imei){
        deviceInfo deviceInfo = deviceModel.getInstance().getDeviceInfo(imei);
        if(deviceInfo.deviceStatus == "1"){
            if(!alarmBallDic.ContainsKey(imei+ "_alarmBall")){
                addModelToMap(deviceInfo);
            }
        }
        else if(deviceInfo.deviceStatus != "1"){
            deleteModel(deviceInfo);
        }
    }



   private void addModelToMap(deviceInfo value){
        addModel(pathDictionary["alarmBall"], value.position, value.imei + "_alarmBall", value.imei, value.deviceStatus);
   }



   private void addModel(string modelPath, Vector3 position, string name = "model", string parentName = "", string deviceStatus = "0")
   {

        // 烟感 Assets/resources/Prefab/3d/烟感.prefab
        GameObject obj = ResourcesMgr.getInstance().Load<GameObject>(modelPath);
        obj.transform.parent = GameObject.Find(parentName).transform;
        // obj.transform.position = position;
        obj.transform.localPosition = new Vector3(0,0,0);
        // obj.transform.localPosition = position;
        obj.name = name;
        // 添加标签
        obj.tag = "alarmBall";
        alarmBallDic.Add(name, obj);
        // obj.AddComponent<BoxCollider>();
   }

    private void deleteModel(deviceInfo value){
        GameObject.Destroy((alarmBallDic[value.imei+ "_alarmBall"] as GameObject));
        alarmBallDic.Remove(value.imei+ "_alarmBall");
    }

    public void Update()
    {
        
    }




}
