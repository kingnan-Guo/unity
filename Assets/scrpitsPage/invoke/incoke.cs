using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 3秒后调用testFunc
        this.Invoke("testFunc", 3.0f);
        // 5秒后开始重复调用repeatFunc，每次间隔1秒
        this.InvokeRepeating("repeatFunc", 5.0f, 1.0f);
        // 10秒后调用cancelFunc
        this.Invoke("cancelFunc", 10.0f);

    }

    void cancelFunc()
    {
        Debug.Log("cancelFunc");
        // 取消调用 repeatFunc
        this.CancelInvoke("repeatFunc");
    }
    void testFunc()
    {
        Debug.Log("testFunc");
    }
    void repeatFunc()
    {
        Debug.Log("repeatFunc");
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
