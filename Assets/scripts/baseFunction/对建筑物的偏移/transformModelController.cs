using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformModelController
{
    Transform currentFloor;

    private GameObject currentGameObject;

    private Vector3 directionVector3;

    // 记录那些建筑物被拖出
    private Dictionary<string, string> buildingMap = new Dictionary<string, string>();
    
    public transformModelController(){
        // 监听点击的事件 
        EventCenterOptimize.getInstance().AddEventListener<GameObject>("mousePositionPhysics", (res) => {
            Debug.Log("transformModelController == " + res.name);
            getFloor(res);
        });
    }

    private void getFloor(GameObject res){

        currentGameObject = res;

        if(currentFloor !=null && currentFloor.tag == "building"){
            if(currentGameObject.name != currentFloor.name){
                Debug.Log("将 上一个点击的 建筑物 收回 "+ currentFloor.name);
            }
        } 
        
        if(currentFloor == null || (currentFloor !=null && currentGameObject.name != currentFloor.name)) {

            currentFloor = res.transform;

            if(currentFloor != null){
        
                while (currentFloor != null && !currentFloor.gameObject.CompareTag("building"))
                {
                    currentFloor =  currentFloor.parent;
                }

                Debug.Log("currentFloor =="+ currentFloor.name + "== ");

                if(currentFloor != null &&currentFloor.gameObject.CompareTag("building")){
                    Debug.Log("点击 currentFloor =="+ currentFloor.name + "拖出");
                    // Debug.Log("currentParent == "+ currentParent.gameObject.name);
                } else {
                    // Debug.Log("没有 点击在 任何一个建筑物上");        
   
                }
            } else{
                Debug.Log("没有父级");
            }

        }

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
