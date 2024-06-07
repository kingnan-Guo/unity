using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using NamespaceOne;


namespace NamespaceOne
{
    class Test{
        private int a = 1;
        public string b = "2";

        public Test(){
            Debug.Log("执行构造函数 Test");
        }

        public Test(int i){
            this.a = i;
            Debug.Log("执行构造函数 Test(int i) ="+ i);
        }

        public Test(int i, string b):this(i){
            this.b = b;
            Debug.Log("执行构造函数 Test(int i, string b) = "+ b +" i = "+ i);
        }

        public void print(int c){
            Debug.Log("print a = " + this.a + " b = " + this.b);
            Debug.Log("print c = " + c);
        }

    }
}


public class reflectionTest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region  Activator
        // 快速 实例化 对象的 类
        // 用于 将 type 对象快捷实例化 为对象
        // 先得到 Type 对象
        // 然后使用 快速实例话 一个对象

        Type testType = typeof(NamespaceOne.Test);
        // 无参 构造
        Test testObj = Activator.CreateInstance(testType) as Test;
        Debug.Log("testObj = " + testObj.b);

        testObj = Activator.CreateInstance(testType, 3) as Test;
        Debug.Log("testObj = " + testObj.b);


        testObj = Activator.CreateInstance(testType, 3, "str") as Test;
        Debug.Log("testObj = " + testObj.b);

        #endregion



        #region  Assembly 程序集 类
        //主要用来加载 其他 程序集 加载后才能 用  Type 来 使用 其他程序集 的 信息

        // 如果 要使用不是自己程序集 中 的内容，需要 先加载程序集
        // eg： dll文件 （库文件）
        // 简单的把库 文件 开成 一种 大妈仓库 ，它提供使用者 一些可以直接拿来使用 的变量、 函数类


        // 三种 加载 程序集 的 函数
        // 一般 用来加载在 同一 问价下的其他程序 集
        // 1. Assembly assembly= Assembly.Load(“程序集名称”)
        
        // 用于加载不在 同一文件下的其他程序集
        // 1. Assembly.LoadFrom(”包含程序集清淡的文件的名称和 路径“)
        // 2. Assembly.LoadFile(” 要加载的 文件的完全 限定路径“)

        //1、 先加载一个 程序集

        // Assembly assembly = Assembly.LoadFrom(@"/Users/kingnan/Documents/github/unity/Assets/scripts/反射/reflectionTest");
        // Type[] types = assembly.GetTypes();

        // foreach (Type type in types)
        // {
        //     Debug.Log("type = " + type);
        // }

        #endregion



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
