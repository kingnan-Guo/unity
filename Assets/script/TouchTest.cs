// 触摸
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 开启多点 触摸
        Input.multiTouchEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Debug.Log("单点触摸");

            // 获取触摸 对象
            Touch touch  = Input.touches[0];
            
            Debug.Log("触摸点位置：" + touch.position);

            // 触摸点 状态
            switch (touch.phase){

                case TouchPhase.Began:
                    Debug.Log("触摸点开始触摸");
                    break;
                case TouchPhase.Moved:
                    Debug.Log("触摸点正在移动");
                    break;
                case TouchPhase.Ended:
                    Debug.Log("触摸点结束触摸");
                    break;
                case TouchPhase.Canceled:
                    Debug.Log("触摸点取消触摸");
                    break;
                default:
                    break;
            }
        }

        // 判断多点 触摸
        if (Input.touchCount == 2)
        {
            Debug.Log("多点触摸");
            Touch touch1 = Input.touches[0];
            Touch touch2 = Input.touches[1];

            Debug.Log("触摸点1位置：" + touch1.position);

            Debug.Log("触摸点2位置：" + touch2.position);
        }
    }
}
