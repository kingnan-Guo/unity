using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动画管理器
// 用于对建筑物的动画进行管理
// 例如：建筑物的动画播放、暂停、停止等
public class modelAnimation : baseManager<modelAnimation>
{

    private Dictionary<string, buildingClass> buildingMapAnimation = new Dictionary<string, buildingClass>();

    public modelAnimation(){

        // MonoManager.getInstance().AddUpdateListener(myUpdate);
        // EventCenterOptimize.getInstance().AddEventListener<buildingClass>("buildingPush", (res) => {
        //     Debug.Log("buildingPush = "+ res.name);
        // });
    
    }


    // 拉出楼层
    public void PullOut( buildingClass building)
    {
        // 在这里实现拉出楼层的逻辑

        // buildingMapAnimation.Add(building.name, building);

        // foreach (string key in buildingMapAnimation.Keys){
        //     buildingMapAnimation[key].transform.position = Vector3.Lerp(buildingMapAnimation[key].startPosition, buildingMapAnimation[key].endPosition, 1);
        // }
        buildingMapAnimation.Add(building.name, building);

        // for (float i = 0.0f; i < 10.0f; i++)
        // {
        //     building.transform.position = Vector3.Lerp(building.startPosition, building.endPosition, i/10);
        // }
        building.transform.position = Vector3.Lerp(building.startPosition, building.endPosition, 1);

    }

    // 将楼层放回原位
    public void PushBack(buildingClass building)
    {
        // 在这里实现将楼层放回原位的逻辑
        // buildingMapAnimation.Add(building.name, building);

        // foreach (string key in buildingMapAnimation.Keys){
        //     buildingMapAnimation[key].transform.position = Vector3.Lerp(buildingMapAnimation[key].startPosition, buildingMapAnimation[key].endPosition, 1);
        // }

        building.transform.position = Vector3.Lerp(building.startPosition, building.endPosition, 1);
        buildingMapAnimation.Remove(building.name);

    }
}
