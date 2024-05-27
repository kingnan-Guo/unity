using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePlayerControl : MonoBehaviour
{
    private CharacterController CapsulePlayer;//跟 模型的名字没有 关系
    // Start is called before the first frame update
    void Start()
    {
        CapsulePlayer = GetComponent<CharacterController>();
        // Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("horizontal" + horizontal + "vertical" + vertical);
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        Debug.DrawLine(transform.position, dir, Color.red);

        // 移动 ; 有重力 的移动
        CapsulePlayer.SimpleMove(dir);
    }
}
