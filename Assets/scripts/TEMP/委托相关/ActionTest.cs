using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // C# 的委托
        System.Action ac = () => { Debug.Log("hello"); };
        ac();
        System.Action<int, float> ac2 = (x, f) => { Debug.Log("hello" + x + " ="+ f); };
        ac2(1, 2.0f);

        // 有返回值的 ;  前两个 时  传值的 类型 ;最后一个 int 时返回值
        System.Func<int, float, int> fc = (x, f) => { return x + (int)f; };
        int result = fc(1, 2.0f);
        Debug.Log(result);


        // Unity 的委托; unity  没哟 带返回值的 问题拖
        UnityAction uac = () => {
            print("UnityAction 的委托");
        };
        uac();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
