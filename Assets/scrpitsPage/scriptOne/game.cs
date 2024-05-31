using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        game self= this.GetComponent<game>();// 当前节点下 名称为 game 的组件 实例

        Debug.Log(self.name);

        GameObject gameObject = this.transform.gameObject;

        Transform transform = GetComponent<Transform>();

        // game game_new_com = this.gameObject.AddComponent<game>();
        testFunction testFun = this.gameObject.AddComponent<testFunction>();
        testFun.test_function();

        // 通过名字 查找 要 强转
        testFunction testFun2 =(testFunction)this.GetComponent("testFun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}


// 组件都是  类，组件保定到 gameObject 上 是  new  实例化 的过程

// transform  是 结构体  不可以继承，


// 可以 先找 节点 再找 节点上的组件实例