using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 渲染层
/// </summary>


public class addModelToMap
{

    Dictionary<string, string> pathDictionary = new Dictionary<string, string>();
    // 烟感 Assets/resources/Prefab/3d/烟感.prefab
    // pathDictionary.Add("烟感", "Prefab/3d/烟感");
        // 烟感 Assets/resources/Prefab/3d/烟感.prefab
   public addModelToMap(){
        pathDictionary.Add("deviceType83_40", "Prefab/3d/烟感");
        EventCenterOptimize.getInstance().AddEventListener<Dictionary<string, object>>("DeviceInfoDictionary", (DictionaryArr) => {
            Debug.Log("addModelToMap 获取到的 设备的 数组 DeviceInfoDictionary =="+ DictionaryArr);


            foreach (string key in DictionaryArr.Keys)
            {

                deviceInfo value = DictionaryArr[key] as deviceInfo;
                addDeviceModel(pathDictionary[value.deviceType], value.position, value.imei, value.orgName, value.deviceStatus);
                // Debug.Log("value.deviceType =="+ value.deviceType + "  value.position =="+ value.position);
                // Debug.Log("item =="+ DictionaryArr[key]);
            }

        });


        // 监听 点位信息是否改变
        EventCenterOptimize.getInstance().AddEventListener<eventContent>("upDateDeiveInfo", (res) => {
            upDateData<eventContent>(res);
        });


   }



   private void addDeviceModel(string modelPath, Vector3 position, string name = "model", string parentName = "", string deviceStatus = "0")
   {

        // 烟感 Assets/resources/Prefab/3d/烟感.prefab
        GameObject obj = ResourcesMgr.getInstance().Load<GameObject>(modelPath);
        
        
        // obj.SetActive(true);
        
        obj.transform.parent = GameObject.Find(parentName).transform;
        obj.transform.position = position;
        obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // obj.transform.localPosition = position;
        obj.name = name;
        obj.GetComponent<Renderer>().material.color = Color.white;
        if(int.Parse(deviceStatus) == 1){
            obj.GetComponent<Renderer>().material.color = Color.red;
        }
        // 添加标签
        obj.tag = "device";
        obj.AddComponent<BoxCollider>();
        // 添加点击事件
        // obj.AddComponent<ClickEvent>();



        // obj.GetComponent<Renderer>().material.color = Color.red;
        // obj.GetComponent<Renderer>().material.color = Color.red;

   }

    // 根据事件类型  
   public void upDateData<T>(T data) where T : eventContent
   {
    deviceEventType type = data.eventType;
    switch (type)
    {
        case deviceEventType.changeDeviceInfo:
            upDateDeviceStatus(data.imei);
            break;
        case deviceEventType.addDevice:

            break;
        default:
            break;
    }

   }

   // 更新点位状态
    public void upDateDeviceStatus(string imei){
        Debug.Log("upDateDeviceStatus  imei =="+ imei);

        deviceInfo deviceInfo = deviceModel.getInstance().getDeviceInfo(imei);


        // GameObject 
        GameObject building = GameObject.Find(deviceInfo.orgName);
        
        GameObject go = building.transform.Find(imei).gameObject;
        go.GetComponent<Renderer>().material.color = Color.white;
        if(deviceInfo.deviceStatus == "1"){
            go.GetComponent<Renderer>().material.color = Color.red;
        }

    }

}
