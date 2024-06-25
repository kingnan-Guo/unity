using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasOfModelInfo
{

    private GameObject canvas;
    private GameObject currentGameObject;
    private List<string> arr = new List<string>(){ "正常", "故障", "报警", "离线", "屏蔽"};

    private Dictionary<string, string> typeDic = new Dictionary<string, string>();

    

    public canvasOfModelInfo(){

        typeDic.Add("deviceType83_40", "烟感探测器");
        //添加边框

        EventCenterOptimize.getInstance().AddEventListener<GameObject>("mouseMovePositionPhysics", (res) => {
            
            if(res != null){
                // Debug.Log("canvasOfModelInfo mouseMovePositionPhysics == " + res.name);
                currentGameObject = res;

                // currentGameObject 设置材质
                currentGameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/test");

                deviceInfo deviceInfo = deviceModel.getInstance().getDeviceInfo(res.name);
  
                if(canvas == null){
                    
                   canvas = this.createCanvasGameObject(res.transform.position);

                    // 查找 canvas 下的text
                    Text text = GameObject.Find("deviceName").GetComponent<Text>();
                    // 设置 text 的文本
                    text.text = deviceInfo.deviceName;

                    text = GameObject.Find("deviceStatus").GetComponent<Text>();
                    text.text = arr[int.Parse(deviceInfo.deviceStatus)];

                    text = GameObject.Find("deviceType").GetComponent<Text>();
                    text.text = typeDic[deviceInfo.deviceType];

                    text = GameObject.Find("imei").GetComponent<Text>();
                    text.text = deviceInfo.imei;
                    Debug.Log("deviceInfo.imei = "+ deviceInfo.imei);


                //    canvas.transform.forward = 
                   Debug.Log("canvas =="+ text);
                //    GameObject.Instantiate(canvas);
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

    public void Update(){
        if(canvas != null){
            Transform cameraTransform = GameObject.Find("Main Camera").transform;
            canvas.transform.LookAt(new Vector3(cameraTransform.position.x, canvas.transform.position.y, cameraTransform.position.z));
            canvas.transform.Rotate(0, 180, 0);
        }
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
