using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cubeButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("cubeButtonControl Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnCollisionEnter(Collision collision){
    //     // 碰撞物体
    //     Debug.Log(collision.gameObject.name);
    // }

    // other 进入 触发 的碰撞器
    private void OnTriggerEnter(Collider other){
        Debug.Log("进入 触发器");
        GameObject door = GameObject.Find("door");
        if(door != null){
            door.SetActive(false);
        }

    }
    
    private void OnTriggerStay(Collider other){

    }

    // private void OnTriggerExit(Collider other){

    // }
}
