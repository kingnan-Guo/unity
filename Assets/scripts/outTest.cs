using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class outTest : MonoBehaviour
{
    public static int PROTO_TYPE = 10;// 不属于 实例 属于 class 对象 ，可以使用 outTest.PROTO_TYPE 访问；公共访问; 一旦分配 永远都在; 不会消失，会生成 exe
    public static void  test_function(int a){
        Debug.Log("public static void  test_function ="+ a);
    }

    public const int const_val = 0; // 没有内存， 在编译的时候 会对引用到的 地方做常量的替换 



    class Point{

    }
    bool raycast_item(out int size, out Point p){
        size = 10;
        p = new Point();
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        int a;
        Point p;
        bool res = raycast_item(out a, out p);
        Debug.Log(res);
        Debug.Log(a);

        char ch='A';
        Debug.Log(ch);
        Debug.Log((int)ch);

        int year = 2024;
        int mon = 5;

        string str = string.Format("{0}-{1}", year, mon);
        Debug.Log(str);
        Debug.Log(str.Equals("2024-5"));

        int start_index = str.IndexOf("-5", 0);
        Debug.Log(start_index);

        Debug.Log(outTest.PROTO_TYPE);
        outTest.PROTO_TYPE = 99;
        Debug.Log(outTest.PROTO_TYPE);

        outTest.test_function(outTest.PROTO_TYPE);

        Debug.Log(outTest.const_val);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


// out 机制 返回值 是不是一个
// 碰撞检测：  返回值 = （是不是碰撞了 碰撞了谁），想要两个返回值


// 泛型 

