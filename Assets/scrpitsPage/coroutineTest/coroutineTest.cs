using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        IEnumerator r =  this.Test();// 协程 对象 ; 并没有 执行
        Debug.Log("star coroutine");
        // 启动协程 ; 并保存 为 协程 对象   coroutine
        Coroutine coroutine = this.StartCoroutine(r);
        this.StopCoroutine(coroutine);// 停止协程
        this.StartCoroutine("Test");// 传名字 也可以启动协程
        Debug.Log("end coroutine");


        Debug.Log("star coroutine2");
        this.StartCoroutine(Test_for());
        Debug.Log("end coroutine2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 协程 的 处理函数
    IEnumerator Test(){
        
        Debug.Log("do  Test");
        yield return new WaitForSeconds(3);// 等待 3 秒 后 再执行 下面的程序； 实现补卡主 主线程 的情况下  直接 延时 3 秒
        yield return null;// yield return 中断当前的 协程 程序； yield return null 下一帧 中断 协程 程序，也就是 先执行 end，再执行 do
        yield break; // 终止 协程 不会再  执行 下面的程序
        // Debug.Log("do  Test yield return");
        // Debug.Log("do  Test yield return");

    }

    IEnumerator Test_for(){
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("do  Test_for"+ i);
            yield return null;
        }
        // yield return null;
        // yield break;
    }

}

// 协程 
//1、 仍是在主程序里面运行的 ，不是 多线程
//2、 另外一段逻辑处理 和 当前程序在一起协同 执行
//3、 协程 必须 配合 迭代器 一起使用
// upDate 模型 的 unity 已经帮我们做好了
//
// 使用协程 的步骤
//  1、 创建一个  函数 ，必须要以 IEnumerator  作为 返回值

//  2、 在函数里面 写上 需要 执行的 代码



// IEnumerator  协程的代码 容器 对象 