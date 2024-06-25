using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
                addDeviceModel(pathDictionary[value.deviceType], value.position, value.imei, value.orgName);
                // Debug.Log("value.deviceType =="+ value.deviceType + "  value.position =="+ value.position);
                // Debug.Log("item =="+ DictionaryArr[key]);
            }

        });
   }



   private void addDeviceModel(string modelPath, Vector3 position, string name = "model", string parentName = "")
   {

        // 烟感 Assets/resources/Prefab/3d/烟感.prefab
        GameObject obj = ResourcesMgr.getInstance().Load<GameObject>(modelPath);
        // obj.transform.position = position;
        
        // obj.SetActive(true);
        
        obj.transform.parent = GameObject.Find(parentName).transform;
        obj.transform.localPosition = position;
        obj.name = name;
        obj.GetComponent<Renderer>().material.color = Color.red;
        // obj.GetComponent<Renderer>().material.color = Color.red;
        // obj.GetComponent<Renderer>().material.color = Color.red;

   }
}
