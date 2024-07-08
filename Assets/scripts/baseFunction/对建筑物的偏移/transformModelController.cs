using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class buildingClass{
    public string name;
    public Vector3 position;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public int speed;
    public Transform transform;

}

public class transformModelController
{
    Transform currentFloor;

    private GameObject currentGameObject;

    private Vector3 directionVector3;


    buildingClass building = new buildingClass();

    // 记录那些建筑物被拖出
    private Dictionary<string, Transform> buildingMap = new Dictionary<string, Transform>();
    
    public transformModelController(){
        // 监听点击的事件 
        EventCenterOptimize.getInstance().AddEventListener<GameObject>("mousePositionPhysics", (res) => {
            Debug.Log("transformModelController == " + res.name);
            getFloor(res);
        });


        EventCenterOptimize.getInstance().AddEventListener<string>("back", (res) => {
            pushAllBack();
        });

    }

    private void getFloor(GameObject res){

        currentGameObject = res;

        if(currentFloor !=null && currentFloor.tag == "building"){

            Transform newGameObject = currentGameObject.transform;
            while (newGameObject != null && !newGameObject.gameObject.CompareTag("building"))
            {
                newGameObject =  newGameObject.parent;
            }

            if(newGameObject.name != currentFloor.name){
                Debug.Log("将 上一个点击的 建筑物 收回 "+ currentFloor.name);

                    // buildingClass building = new buildingClass();
                    building.name = currentFloor.name;
                    building.position = currentFloor.position;
                    building.startPosition = currentFloor.position;
                    building.endPosition = currentFloor.position  - Vector3.forward * 50f;
                    building.speed = 1;
                    building.transform = currentFloor;
                    // 拖出
                    modelAnimation.getInstance().PushBack(building);
                    buildingMap.Remove(currentFloor.name);

            }
        } 
        
        if(currentFloor == null || (currentFloor !=null && currentGameObject.name != currentFloor.name)) {

            currentFloor = res.transform;

            if(currentFloor != null){
        
                while (currentFloor != null && !currentFloor.gameObject.CompareTag("building"))
                {
                    currentFloor =  currentFloor.parent;
                }

                // Debug.Log("currentFloor =="+ currentFloor.name + "== ");

                if(currentFloor != null &&currentFloor.gameObject.CompareTag("building")){
                    // Debug.Log("点击 currentFloor =="+ currentFloor.name + "拖出");


                    // 节流
                    if(!buildingMap.ContainsKey(currentFloor.name)){
                        buildingMap.Add(currentFloor.name, currentFloor);

                        
                        building.name = currentFloor.name;
                        building.position = currentFloor.position;
                        building.startPosition = currentFloor.position;
                        building.endPosition = currentFloor.position  + Vector3.forward * 50f;
                        building.speed = 1;
                        building.transform = currentFloor;

                        // 拖出
                        // EventCenterOptimize.getInstance().EventTrigger<buildingClass>("buildingPush", building);
                        modelAnimation.getInstance().PullOut(building);

                        return;
                    }


                    


                    // 拖入
                    // EventCenterOptimize.getInstance().EventTrigger<buildingClass>("buildingPull", building);
                    // modelAnimation.getInstance().PushBack(building);

                  
                } else {
                    // Debug.Log("没有 点击在 任何一个建筑物上");        
   
                }
            } else{
                Debug.Log("没有父级");
            }

        }

    }


    public void pushAllBack(){
        building.name = currentFloor.name;
        building.position = currentFloor.position;
        building.startPosition = currentFloor.position;
        building.endPosition = currentFloor.position  - Vector3.forward * 50f;
        building.speed = 1;
        building.transform = currentFloor;
        // 拖出
        modelAnimation.getInstance().PushBack(building);
        buildingMap.Remove(currentFloor.name);
        currentFloor = null;
    }

    // 推
    private void push(GameObject building){

    }

    // 拉
    private void pull(GameObject building){

    }

    public void Update()
    {
        
    }
}
