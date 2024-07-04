using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class buildingAlarmAinmation
{

    private float shake;

    private Material material_back;

    Material buildingAlarm = Resources.Load<Material>("Materials/buildingAlarm");
    private Dictionary<string, List<string>> buildingAlarmObject = new Dictionary<string, List<string>>();
    public buildingAlarmAinmation(){

        Material material = GameObject.Find("floor_19_e").GetComponent<Renderer>().material;

        if(material_back == null){
            material_back = new Material(material);
        }
               

        // 接收 报警推送
        EventCenterOptimize.getInstance().AddEventListener<eventContent>("upDateDeiveInfo", (res) => {
            // upDateData<eventContent>(res);
            upDateData<eventContent>(res);
            
        });
    }
   private void upDateData<T>(T data) where T : eventContent
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



    private void upDateInfo(string imei){
        deviceInfo deviceInfo = deviceModel.getInstance().getDeviceInfo(imei);
        if(deviceInfo.deviceStatus == "1"){

            if(!buildingAlarmObject.ContainsKey(deviceInfo.orgName)){
                // buildingAlarmObject.Add(deviceInfo.orgName, deviceInfo.deviceStatus);
                buildingAlarmObject.Add(deviceInfo.orgName, new List<string>());
                buildingAlarmObject[deviceInfo.orgName].Add(deviceInfo.imei);
            } else {
                buildingAlarmObject[deviceInfo.orgName].Add(deviceInfo.imei);
            }
            
        }
        else if(deviceInfo.deviceStatus != "1"){

            if(buildingAlarmObject.ContainsKey(deviceInfo.orgName)){
                buildingAlarmObject[deviceInfo.orgName].Remove(deviceInfo.imei);
                if(buildingAlarmObject[deviceInfo.orgName].Count == 0){
                    changeMaterial(material_back);
                    buildingAlarmObject.Remove(deviceInfo.orgName);
                }

            }
            
            // buildingAlarmObject.Remove(deviceInfo.orgName);
        }
    }

    // 延时执行
    public IEnumerator delayAction(float delayTime, System.Action action)
    {
        yield return new WaitForSeconds(delayTime);
        action();
    }

    public void startAction(){
        // StartCoroutine(delayAction(1, () => {

        // }));

        MonoManager.getInstance().StartCoroutine(delayAction(0.5f, () => {
            // Debug.Log(" 0.5秒 执行一次  startAction");

            changeMaterial(material_back);

        }));
    }


    private void changeMaterial(Material material){
        foreach (string item in buildingAlarmObject.Keys)
        {
            GameObject.Find(item).gameObject.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(material);
        }

    }

    public void Update(){

        if (shake >1)
        {
            // currentGameObject.GetComponent<MeshRenderer>().enabled=true;
            Debug.Log(" 一秒 执行一次");


            // buildingAlarmObject.Keys.GetEnumerator().MoveNext();
            changeMaterial(buildingAlarm);

            startAction();

            shake = 0;
        }

        shake += Time.deltaTime;

    }
}
