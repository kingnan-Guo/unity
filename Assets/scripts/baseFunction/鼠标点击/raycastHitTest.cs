using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class raycastHitTest : MonoBehaviour
{

    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("raycastHitTest");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;//   碰撞点 是 世界 坐标系
            bool res = Physics.Raycast(ray,out hit);
            if(res){
                // 如果 物体上没有  collider 组件 则 无法 获取 碰撞点 ； 要求 都挂上 collider 组件
                // maxDistance 射线 最大 距离、
                // 除了 射线检测 还可以是 origin direction 检测
                // layerMask  忽略 一些
                Debug.Log(hit.collider.name);

                // Debug.Log(Vector3.forward );
                Debug.Log(Time.deltaTime);
                // go
                go = hit.transform.gameObject;


                //点击后 把事件 发给 事件中心 

                EventCenterOptimize.getInstance().EventTrigger<GameObject>("mousePositionPhysics", hit.transform.gameObject);
                
            }
        }


        if(Input.GetMouseButtonDown(1)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //   碰撞点 是 世界 坐标系
            RaycastHit[] hits = Physics.RaycastAll(ray);
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].collider.name);
            }
        }

        
    }
}