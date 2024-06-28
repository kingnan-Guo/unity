using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class canvasOfModelInfo
{

    private GameObject canvas;
    private GameObject mainCanvas;
    private GameObject currentGameObject;
    private List<string> arr = new List<string>(){ "正常", "报警", "离线", "屏蔽", "故障", "正常"};

    private Dictionary<string, string> typeDic = new Dictionary<string, string>();

    private float shake;

    private Material material_back;

    Transform currentFloor;

    public canvasOfModelInfo(){

        typeDic.Add("deviceType83_40", "烟感探测器");
        //添加边框

        Material material = GameObject.Find("floor_19_e").GetComponent<Renderer>().material;

        if(material_back == null){
            material_back = new Material(material);
        }
                            



        if(mainCanvas == null){
            mainCanvas = createMianCanvasGameObject();

            // Button[] controls = mainCanvas.transform.GetComponentsInChildren<Button>();

            // Debug.Log("controls ====", (controls[0] as GameObject).name);
            // controls[0].onClick.AddListener(() =>{
            //         Debug.Log("alarmButton == click ==");
            // });
            // Debug.Log("controls =="+ controls.Count);
            // controls[0].onClick.AddListener(() => {
            //     Debug.Log("alarmButton == click ==");
            // });

            // Button[] controls = mainCanvas.transform.GetComponentsInChildren<Button>();
                
            // Debug.Log("controls ===="+ controls[0].name);

            // controls[0].onClick.AddListener(() =>{
            //     Debug.Log("alarmButton == click ");
            // });

            // Text text = controls[0].transform.Find("Text (Legacy)").GetComponent<Text>();

            // text.text = "asd";
        //    Button btn =  mainCanvas.Find("alarmButton");
            // .onClick.AddListener(() =>{
            //         Debug.Log("alarmButton == click ==");
            // })


        }


        EventCenterOptimize.getInstance().AddEventListener<GameObject>("mouseMovePositionPhysics", (res) => {

              if(res != null){


                // if(currentGameObject == null ||  currentGameObject!=null && currentGameObject.name != res.name){
                    if(currentFloor !=null && currentFloor.tag == "building"){
                        if(material_back != null){
                            // currentGameObject.GetComponent<Renderer>().material = material_back;
                            currentFloor.gameObject.GetComponent<Renderer>().material = material_back;
                        }
                    }
                    currentGameObject = res;
                // }
                
                // MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
                // res.GetComponent<Renderer>().GetPropertyBlock(propertyBlock);
                // propertyBlock.SetColor("_Color", Color.blue);
                // res.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);


                // 获取 GameObject 的材质
                // Material material = currentGameObject.GetComponent<Renderer>().material;

                // Debug.Log("canvasOfModelInfo mouseMovePositionPhysics == " + material);

                // if(res.tag == "building" && false){
                //     // Debug.Log("currentParent =="+ res.name);


                //     // Material material = res.GetComponent<Renderer>().material;
                //     // // 拷贝 material
                //     // if(material_back == null){
                //     //     material_back = new Material(material);
                //     // }
                //     // material.color = Color.blue;

                //     // Debug.Log("material_back =="+ material_back);

                // } 
                // else {

                //     Transform currentParent = res.transform;
            
                //     while (currentParent != null && currentParent.gameObject.tag != "building")
                //     {
                //         currentParent = currentParent.parent;
                //     }

                //     if(currentParent != null && currentParent.gameObject !=null){
                //         if(currentParent.gameObject.tag == "building"){

                //             Material material = currentParent.gameObject.GetComponent<Renderer>().material;

                //             if(material_back == null){
                //                 material_back = new Material(material);
                //             }
                            
                //             Text text = mainCanvas.transform.Find("floorName").GetComponent<Text>();
                //             // 设置 text 的文本
                //             text.text = currentParent.name;

                //              material.color = Color.blue;
                //         }
                //     }
                //     // 拷贝 material
                // }




                currentFloor = res.transform;

                if(currentFloor != null) {
                    // return ;

                    // currentFloor = res.transform;

                    if(currentFloor != null){
                
                        while (currentFloor != null && !currentFloor.gameObject.CompareTag("building"))
                        {
                            currentFloor =  currentFloor.parent;
                        }

                        Debug.Log("currentFloor =="+ currentFloor.name + "== ");

                        if(currentFloor != null &&currentFloor.gameObject.CompareTag("building")){
                            
                            Material material = currentFloor.gameObject.GetComponent<Renderer>().material;

                            Text text = mainCanvas.transform.Find("floorName").GetComponent<Text>();
                            // 设置 text 的文本
                            text.text = "当前楼层" + currentFloor.name;

                            if(material.color != Color.blue){
                                material.color = Color.blue;
                            }

                            // Debug.Log("currentParent == "+ currentParent.gameObject.name);
                        } else {
                            Debug.Log("没有 悬浮在 任何一个建筑物上");        
                            if(currentGameObject !=null && currentGameObject.tag == "building"){
                                if(material_back != null){
                                    currentGameObject.GetComponent<Renderer>().material = material_back;
                                }
                            }
                        }
                    } else{
                        Debug.Log("没有父级");
                    }


                }









            }




            if(res != null && res.transform.gameObject.tag == "device"){

                
                // Debug.Log("canvasOfModelInfo mouseMovePositionPhysics == " + res.name);
                currentGameObject = res;


                // currentGameObject 设置材质
                // currentGameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/test");

                deviceInfo deviceInfo = deviceModel.getInstance().getDeviceInfo(res.name);
  
                if(canvas == null){
                    
                   canvas = this.createCanvasGameObject(res.transform.position);

                    // 查找 canvas 下的text
                    Text text = GameObject.Find("deviceName").GetComponent<Text>();
                    // 设置 text 的文本
                    text.text = deviceInfo.deviceName;

                    text = GameObject.Find("deviceStatus").GetComponent<Text>();
                    text.text = arr[int.Parse(deviceInfo.deviceStatus)];

                    if(int.Parse(deviceInfo.deviceStatus) == 1){
                        text.color = Color.red;
                    } else if(int.Parse(deviceInfo.deviceStatus) == 5){
                        text.color = Color.green;
                    }

                    text = GameObject.Find("deviceType").GetComponent<Text>();
                    text.text = typeDic[deviceInfo.deviceType];

                    text = GameObject.Find("imei").GetComponent<Text>();
                    text.text = deviceInfo.imei;
                    // Debug.Log("deviceInfo.imei = "+ deviceInfo.imei);


                    //    canvas.transform.forward = 
                    Debug.Log("canvas =="+ text);
                    //    GameObject.Instantiate(canvas);

            

                // MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
                // res.GetComponent<Renderer>().GetPropertyBlock(propertyBlock);
                // propertyBlock.SetColor("_Color", Color.blue);
                // res.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);




                }

                
            } else {
                // Debug.Log("mouseMovePositionPhysics == null");
                GameObject.Destroy(canvas);
                if(currentGameObject != null){
                    // currentGameObject.GetComponent<Renderer>().material = ;
                }
                canvas = null;
            }




            // 给 gameObject 添加边框
            // res.AddComponent<MeshOutline>().OutlineColor = Color.red;
            // res.AddComponent<MeshOutline>().OutlineWidth = 10;
        });

    }


    // 创建 canvas
    private GameObject createCanvasGameObject(Vector3 position){
        // 创建 canvas
        // GameObject canvas = new GameObject("canvas");
        // canvas.AddComponent<Canvas>();
        // // 坐标系为 世界坐标系
        // canvas.transform.position = position;
        // // 设置 canvas 的大小
        // canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 180);
        // // 设置 canvas 的层级
        // canvas.transform.SetAsLastSibling();
        // 设置 canvas 的背景色

        // // canvas 添加按钮
        // canvas.AddComponent<Button>();
        // // 设置按钮的点击事件
        // canvas.GetComponent<Button>().onClick.AddListener(() => {
        //     Debug.Log("canvas click");
        // });
        // 设置按钮的文本
        // Text text = canvas.AddComponent<Text>();
        // text.text = "canvas";
        // // 设置按钮的文本颜色
        // text.color = Color.red;
        // // 设置按钮的文本大小
        // text.fontSize = 20;



        // ===========
        // 找到 canvas 对象  

        GameObject gameObject = ResourcesMgr.getInstance().Load<GameObject>("Prefab/deviceUI/Canvas");
        // canvas = gameObject.transform as RectTransform;
        // canvas = gameObject;
        
        gameObject.transform.position = position + new Vector3(0, 2, 0);
        gameObject.transform.SetAsLastSibling();
        gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0);



        // 设置 canvas 的大小
        // gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 180);
        // // 设置 canvas 的层级
        // gameObject.transform.SetAsLastSibling();
        // // 设置 canvas 的背景色
        // gameObject.GetComponent<Image>().color = Color.gray;
        // // 设置 canvas 的层级
        // // 过场景不移除
        // GameObject.DontDestroyOnLoad(gameObject);

        // bottom = canvas.Find("Bottom");
        // middle = canvas.Find("Middle");
        // top = canvas.Find("Top");
        // system = canvas.Find("System");

            
        // 找到 EventSystem 对象
        // gameObject =ResourcesMgr.getInstance().Load<GameObject>("baseProject/UI/EventSystem");
        //     // 过场景不移除
        // GameObject.DontDestroyOnLoad(gameObject);


        return gameObject;

    }



    // 创建 canvas
    private GameObject createMianCanvasGameObject(){
        GameObject gameObject = ResourcesMgr.getInstance().Load<GameObject>("Prefab/deviceUI/mainCanvas");
        ResourcesMgr.getInstance().Load<GameObject>("Prefab/deviceUI/EventSystem");
        return gameObject;
    }



    public void Update(){
        if(canvas != null){
            Transform cameraTransform = GameObject.Find("Main Camera").transform;
            canvas.transform.LookAt(new Vector3(cameraTransform.position.x, canvas.transform.position.y, cameraTransform.position.z));
            canvas.transform.Rotate(0, 180, 0);
        }



        if (shake >1)
        {
            // currentGameObject.GetComponent<MeshRenderer>().enabled=true;
            // Debug.Log(" 一秒 执行一次");
            shake = 0;
        }

        shake += Time.deltaTime;
    }

    private void DelayRe() {
        
    }

    public void OnDestroy(){
        if(canvas != null){
            GameObject.Destroy(canvas);
        }
    }

    public void OnDisable(){
        if(canvas != null){
            GameObject.Destroy(canvas);
  
            // canvas.transform.Rotate(0, 180, 0);
        }
    }
}
