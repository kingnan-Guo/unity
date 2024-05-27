using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    // CharacterController CapsulePlayer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("playerControl Start");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        // Debug.Log("horizontal" + horizontal + "vertical"+ vertical);
        transform.Translate(dir * 2 * Time.deltaTime);// 每秒2米
    }
}
