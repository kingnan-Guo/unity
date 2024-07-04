using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class functionManagerInheritMono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transformPosition transformPosition = new transformPosition();
        MonoManager.getInstance().AddUpdateListener(transformPosition.Update);

        getDeviceInfo getDeviceInfo = new getDeviceInfo();
        MonoManager.getInstance().AddUpdateListener(getDeviceInfo.Update);


        // EventCenter.getInstance().AddEventListener("KeyDown", InputEvent);
        // EventCenter.getInstance().AddEventListener("KeyUp", InputEvent);


        getGameObjectThroughMousePosition getGameObjectThroughMousePosition = new getGameObjectThroughMousePosition();
        MonoManager.getInstance().AddUpdateListener(getGameObjectThroughMousePosition.Update);



        mouseInputMgr.getInstance();
        
        // EventCenter.getInstance().AddEventListener("鼠标点击左键", (res) => {
        //     Debug.Log("鼠标点击左键"+ res);
        // });

        // JsonDataManager jsonDataManager = new JsonDataManager();
        // MonoManager.getInstance().AddUpdateListener(jsonDataManager.Update);

        // JsonDataManagerDemo jsonDataManagerDemo = new JsonDataManagerDemo();
        // MonoManager.getInstance().AddUpdateListener(jsonDataManagerDemo.Update);


        canvasOfModelInfo canvasOfModelInfo = new canvasOfModelInfo();
        MonoManager.getInstance().AddUpdateListener(canvasOfModelInfo.Update);
        

        addBoderToModel addBoderToModel = new addBoderToModel();
        MonoManager.getInstance().AddUpdateListener(addBoderToModel.Update);

        addModelToMap addModelToMap = new addModelToMap();


        JsonDataManagerDemo.getInstance();

        alarmBallController alarmBallController = new alarmBallController();
        MonoManager.getInstance().AddUpdateListener(alarmBallController.Update);



        transformModelController transformModelController = new transformModelController();
        MonoManager.getInstance().AddUpdateListener(transformModelController.Update);



        // modelAnimation.getInstance();
  


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
