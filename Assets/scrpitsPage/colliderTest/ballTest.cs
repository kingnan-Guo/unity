using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// 类型 区分分类


public class ballTest : MonoBehaviour
{

    // 获取碰撞器
    SphereCollider sphereCollider;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        this.sphereCollider = this.GetComponent<SphereCollider>();

        this.body = this.GetComponent<Rigidbody>();
        // 给 刚体 一个 水平向右 初速度
        Vector3 v = this.body.velocity;
        v.x = 10;
        this.body.velocity = v;

        // 刚体的 角速度; 一秒钟 转 一圈
        Vector3 w = this.body.angularVelocity;
        w.x = Mathf.PI * 2;
        this.body.angularVelocity = w;


        // 给刚体 一个  受力 --》 线性速度
        // 冲量 ： f * t = (m * v1  -m * v0); 设置默认 一个时间
        // 给上面一个 力
        this.body.AddForce(new Vector3(0, 100, 0));
        //  方向 相对的力 
        this.body.AddRelativeForce(new Vector3(0, 100, 0));
        // 
        

        // AddTorque 力矩 --》 角速度
        this.body.AddTorque(new Vector3(100, 0, 0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 开始碰撞
    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("碰撞到了"+ collision.gameObject.name);
        // Debug.Log("碰撞到了"+ collision.collider.gameObject.name); // 都可以 

        // 获取 撞到的 刚体; 如果 撞到 的 不是刚体 返回值 为 空
        // Rigidbody curRigidbody = collision.rigidbody;
        // Debug.Log("撞到的 刚体"+ curRigidbody);


    }

    // 碰撞中
    void OnCollisionStay(Collision collision)
    {
        // Debug.Log("碰撞中"+ collision.gameObject.name);
    }


    // 结束碰撞
    void OnCollisionExit(Collision collision){
        // Debug.Log("碰撞 结束"+ collision.gameObject.name);
    }


    // ========================== 需要把 平面 或 球 设置为 触发器
    // 开始 碰撞到触发器
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰撞到了触发器"+ other.gameObject.name);// 
    }


    // 碰撞到触发器 停留
    void OnTriggerStay(Collider other){

    }


    // 结束 碰撞到触发器    
    void OnTriggerExit(Collider other){
        Debug.Log("碰撞 结束"+ other.gameObject.name);
    }

}


// controller  是 所有 碰撞器 的基类

// 在项目管理 中 的  物理 可以设置 plane  和  ball 是否碰撞