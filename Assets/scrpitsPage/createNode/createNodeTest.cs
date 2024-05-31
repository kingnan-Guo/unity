using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createNodeTest : MonoBehaviour
{

    void Awake()
    {
        // 创建 常驻节点 ; 让 this.gameObject 变成 常驻节点， 不会 随着场景切换 而变化
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject newObj = new GameObject("newObj");
        newObj.transform.position = new Vector3(0, 2, 0);
        newObj.transform.SetParent(this.transform);
        cube c = newObj.AddComponent<cube>();// 新加的组件的实例
        c.cube_test();

        GameObject.Destroy(newObj, 5.0f);// 5s后 删除


        // 常驻 节点 ，创建之后，切换场景也不会  被 删除
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
