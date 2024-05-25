using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTest : MonoBehaviour
{
    public GameObject cube;

    // 预设体
    public GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EmptyTest Start");
        //难道当前  脚本 所挂在 的 物体
        // GameObject go = this.gameObject;
        // Debug.Log(go.name);
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.tag);
        Debug.Log(gameObject.layer);
        //立方体 名称
        Debug.Log(cube.name);
        // 是否 激活
        // Debug.Log(cube.active);// 是否根据 父物体 激活状态
        Debug.Log(cube.activeInHierarchy);// 猜测是 根据 父级 继承
        Debug.Log(cube.activeSelf);// 当前自身的激活状态

        // 获取 transforme 组件
        Transform trans = this.transform;
        Debug.Log(trans.position);

        // 获取其他组件
        // BoxCollider bc = GetComponent<BoxCollider>();
        // 获取当前物体 子物体 身上的某个 组件
        // GetComponentInChildren<CapsuleCollider>(bc);
        // 获取当前物体 父物体 身上的某个 组件
        // GetComponentInParent<BoxCollider>();

        // 添加组件
        cube.AddComponent<AudioSource>();
        // 根据 物体名称 获取 物体
        GameObject test = GameObject.Find("test");

        Debug.Log("test.name =" + test.name);

        test = GameObject.FindWithTag("Enemy");
        test.SetActive(false);

        // 通过 预设 来 实例化一个 物体
        // GameObject go2 = Instantiate(Prefab);
        // 添加一个子物体 ； transform 代表 GameObject 当前 的 transform 组件
        GameObject go2 = Instantiate(Prefab, transform);
        // 放到 0 0  的位置，并且不旋转
        GameObject go3 = Instantiate(Prefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
