using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITest : MonoBehaviour
{

    private NavMeshAgent agent;//
    // Start is called before the first frame update
    void Start()
    {
        // 获取代理组件
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // 按下鼠标 自动走过去
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("点击了");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                // 点击位置
                Vector3 point = hit.point;
                // 设置该位置 为 导航目标点
                // agent.transform.position = point;
                agent.SetDestination(point);
            }
            
        }


    }
}
