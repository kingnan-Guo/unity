using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ThreadTest_work : MonoBehaviour
{
    Thread r;
    int a = 77;

    // 用来 加锁 的 对象
    public static Object o = new Object();
    // Start is called before the first frame update
    void Start()
    {
        
        // r = new Thread(thread_with_params);
        // r.Start("hellow world");//启动一个 线程

        // 没有参数的
        r = new Thread(thread_with_no_params);
        r.Start();

        this.thread_with_params("data 1");

        Debug.Log("Start Thread.CurrentThread.ManagedThreadId "+Thread.CurrentThread.ManagedThreadId);

        lock (o)
        {
            Debug.Log("start lock");
        }
    }

    void thread_with_no_params(){
        // 得到锁
        // 锁住 o； 如果有 占用 ，那么就挂起
        lock(o){



            Debug.Log("thread_with_no_params");
            // 获取 当前线程 id 号；多线程的线程 1
            Debug.Log("thread_with_no_params Thread.CurrentThread.ManagedThreadId "+Thread.CurrentThread.ManagedThreadId);

            //这获取 值
            Debug.Log("thread_with_no_params this.a ="+ this.a);// 访问堆上 的实例 

            Thread.Sleep(10000);// 线程 睡眠 ； 不会 卡住 主线程  ；Suspend 挂起
            // Thread.Abort();// 线程 终止
            Debug.Log("thread_with_no_params end");

            // 5s 后 解除 lock
         



        };

    }

    void thread_with_params(object obj){
        // Debug.Log(obj);
        string obj_str = (string)obj;
        Debug.Log(obj_str);
    }

    // Update is called once per frame
    void Update()
    {
        // lock (o)
        // {
        //     Debug.Log("Update lock");
        // }
    }
}

// 

/// <Summary>
/// 线程 与 线程 之间  公用：
/// 代码段： 函数指令、 线程A、可以执行 线程 B 也可以执行； 同一个函数 可以再线程A 执行 也可以再线程 B  执行
/// 堆： （复杂对象 分配的地方）： 线程A 访问对象M 。线程 B 也可以访问； 同一个 New 对象，可以再线程A 、b 使用 ； 复杂类型没有 局部变量
/// 不共用栈： 每个线程 的函数 调用的  参数 / 局部变量 是不同的； 线程 之间不存在 相互调用
/// struct 结构体存在 栈 里 ，不一样


/// function 结束后 线程会 直接 关闭； Thread r = null ；
/// 线程 没有 暂停 只有 挂起； 1、等在条件上 2、 等在 同步上
/// 每个线程都会 对应 一个 线程 id


/// 两个线程 访问 同一个 资源就会有冲突
///通过 lock 的方式 解决这个问题
///1、线程 1 先尝试去 lock； 这是 lock 了
///2、 这是 线程 2 再来 请求 这个 lock 那么就会 挂起 等待。直到 其他线程 unLock 以后，这时  线程2 开始 lock
///3、 lock  与 unlock 之间 ，我们的线程是安全的，并且 有且只有一个线程 访问


/// 访问 资源 没有冲突不用 加锁


/// 避免 死锁
/// L1 L2
///线程1：  L1 ——> L2
///线程2 ：L2 -> L1
/// 当线程1 锁住 L1 等L2， 线程2 锁住 L2 的 等到 L1 的时候 

/// </Summary>


