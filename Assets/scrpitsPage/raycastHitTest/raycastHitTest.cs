using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastHitTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;//   碰撞点 是 世界 坐标系
            bool res = Physics.Raycast(ray,out hit);
            if(res){
                // 如果 物体上没有  collider 组件 则 无法 获取 碰撞点 ； 要求 都挂上 collider 组件
                // maxDistance 射线 最大 距离、
                // 除了 射线检测 还可以是 origin direction 检测
                // layerMask  忽略 一些
                Debug.Log(hit.collider.name);
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

// collider 撞到碰撞器的 组件实例
// 有了组件 实例 就可以获得 

// Physics 对应的  物理系统； (项目设置  物理)； 可以使用代码 修改 重力； 3D 全局管理对象， 管理着我们3d 物理引擎的全局蚕食，和 界面 的 物理 对应
// RaycastHit 对应的  碰撞信息
// Ray 对应的  射线
// ScreenPointToRay 对应的  屏幕坐标系 到 世界坐标系的 转换
