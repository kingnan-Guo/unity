using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class firetest : MonoBehaviour
{
    // 创建一个 爆炸的预设体
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 监听发生碰撞 ； collision 碰撞到的物体
    void OnCollisionEnter(Collision collision){
        // 创建一个  爆炸物体
        Instantiate(Prefab, transform.position, Quaternion.identity);
        //销毁自身
        Destroy(gameObject);
        // 碰撞到的物体的名字
        Debug.Log(collision.gameObject.name);
    }

    // 持续碰撞中
    void OnCollisionStay(){

    }

    // 结束碰撞
    void OnControllerColliderHit(){

    }
}
