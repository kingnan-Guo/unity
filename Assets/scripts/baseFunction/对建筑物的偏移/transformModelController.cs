using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


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

    string curBuildMaterialState = "0";

    private List<Transform> modelList = new List<Transform>();
    private Dictionary<string, Material> buildMaterial= new Dictionary<string, Material>();
    Material perspective = Resources.Load<Material>("Materials/perspective");

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



        EventCenterOptimize.getInstance().AddEventListener<string>("perspective", (res) => {
            Debug.Log("perspective == " + res);
            if(curBuildMaterialState == "0"){
                curBuildMaterialState = "1";
            } else {
                curBuildMaterialState = "0";
            }
            changeBuildingMaterial(curBuildMaterialState);
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
                    building.endPosition = currentFloor.position  + Vector3.forward * 50f;
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
                        building.endPosition = currentFloor.position  - Vector3.forward * 50f;
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
        building.endPosition = currentFloor.position  + Vector3.forward * 50f;
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

    private void changeBuildingMaterial(string curBuildMaterialState){
        // 查找 A 栋建筑物 替换材质
        // GameObject.Find("dahuyuahqu(Clone)");
        Transform ts = GameObject.Find("dahuyuahqu(Clone)").transform;
        Debug.Log(" ==="+ ts.childCount);
        for (int i = 0; i < ts.transform.childCount; i++)
        {

            // Debug.Log("go.transform.GetChild(i).name =="+ goi.transform.GetChild(i).name);
            if(ts.transform.GetChild(i).name.Contains("A_floor")){
                // ts.transform.GetChild(i);
                // buildingList.Add(ts.transform.GetChild(i).gameObject);
                
                Transform cts = ts.transform.GetChild(i);

                if(curBuildMaterialState == "1"){


                    Material buildingMaterial = cts.GetComponent<Renderer>().material;
                    // Debug.Log(" ==="+ cts.name);
                    if(!buildMaterial.ContainsKey(cts.name)){
                        buildMaterial.Add(cts.name, buildingMaterial);
                    }
                    
                    modelList.Add(cts);
                    // buildingMaterial = Resources.Load("buildingMaterial/"+curBuildMaterialState) as Material;
                    cts.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/perspective");




                   cts.tag = "perspectiveBuilding";
                } else {

                    cts.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/floor_bl");
                    cts.tag = "building";


                    
                }
            }
        }


        modelList.ForEach((item)=>{
            recursionModel(item, curBuildMaterialState);
        });


        

    }


    private void recursionModel(Transform ts, string curBuildMaterialState){
        for (int i = 0; i < ts.transform.childCount; i++)
        {
            Transform cts = ts.transform.GetChild(i);
            Material buildingMaterial = cts.GetComponent<Renderer>().material;
            if(!buildMaterial.ContainsKey(cts.name)){
                buildMaterial.Add(cts.name, buildingMaterial);
            }

            // Debug.Log("ts.transform.name ==="+ ts.transform.name);
            if(curBuildMaterialState == "1"){
                if( !cts.name.Contains("shuixiang_a") && !cts.name.Contains("shuiguan") && !cts.name.Contains("xf")){
                    cts.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/perspective");
                }
            } else {
                cts.GetComponent<Renderer>().material = buildMaterial[cts.name];
            }
            if(cts.name.Contains("_nq")){
                cts.gameObject.SetActive((curBuildMaterialState == "0"));
            }


            
        }

    }


}
