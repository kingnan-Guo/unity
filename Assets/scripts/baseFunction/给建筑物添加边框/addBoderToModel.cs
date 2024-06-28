using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addBoderToModel
{
    public addBoderToModel(){
        //添加边框

        EventCenterOptimize.getInstance().AddEventListener<GameObject>("mouseMovePositionPhysics", (res) => {
            
            if(res != null){
                // Debug.Log("mouseMovePositionPhysics == " + res.name);
            } else {
                // Debug.Log("mouseMovePositionPhysics == null");
            }
            // 给 gameObject 添加边框
            // res.AddComponent<MeshOutline>().OutlineColor = Color.red;
            // res.AddComponent<MeshOutline>().OutlineWidth = 10;
        });

    }


    

    public void Update(){

    }
}
