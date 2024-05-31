using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{

    // 创建 预制体 关联
    public GameObject cube_prefab;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PrefabTest 预制体 start");

        // 复制 预制体 
        // 1、实例化 预制体
        GameObject clonePrefab = GameObject.Instantiate(cube_prefab);
        clonePrefab.name = "cube_prefab_clone";

        clonePrefab.transform.SetParent(this.transform, false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// 预制体
// 1. 预制体是资源，可以被拖拽到场景中
// 2. 预制体可以被实例化，实例化出来的对象是游戏对象
// 3. 一个角色 可以复制成 N个
// 4. 预制体可以被修改，修改后，实例化出来的对象也会被修改
// 5.unity 提供一种机制 ： 1、做好一个角色+ 脚本依赖 ； 2、生成一个模板 --> 预制体； 3 复制这个模板就可以 :3_1 :关联预制体的资源 代码 or 手动 绑定
// 6.是一个 内部独立的整体，所以 再预制体里面 不要去绑定外部的节点或组件 实例； 
// 7. 预制体 可以放到多个场景

