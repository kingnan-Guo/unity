using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


class EventDelegationClass{

    // 定义一个委托 的类型 
    // delegate void my_delegate(string name, int age, float height);

    public delegate void MyDelegate(string name, int age, float height);
    public  MyDelegate my_delegate;
    // public Action function_set;

    public delegate void MyDelegateIns(string name, int age, float height);
    public event MyDelegateIns my_delegate_ins;


    public void dispatch(){
        this.my_delegate_ins( "miaomiaoIns", 1, 90.5f);
    }


}


public class EventDelegation : MonoBehaviour
{


    void test_1(string name, int age, float height){
        Debug.Log("test_1"+ name);
    }
    void test_2(string name, int age, float height){
        Debug.Log("test_21"+ name);
    }

    void test_3(){
        Debug.Log("test_3");
    }
    // ==========
    Action a;//  public delegate void Action(); 系统定义 的 不带参数的委托定义类型



    // Start is called before the first frame update
    void Start()
    {
        EventDelegationClass ed = new EventDelegationClass();

        //my_delegate 是一个 容器 可以存下 一个 function
        // 往 容器里添加函数 叫 订阅
        ed.my_delegate += this.test_1;
        ed.my_delegate += this.test_2;

        // 发布 会把 所有的 函数 调用一变
        ed.my_delegate( "miaomiao", 1, 90.5f);

        ed.my_delegate -= this.test_2;

        ed.my_delegate( "miaomiao2", 1, 90.5f);


        //希望外面 可以添加 委托 ，但是 不希望 外面可以发布

        ed.my_delegate_ins += this.test_1;
        // 由于 添加了event 不允许 外部发布
        // ed.my_delegate_ins( "miaomiao", 1, 90.5f);
        ed.dispatch();





        this.a += this.test_3;
        this.a();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// ============= ============
// 事件 委托
// 定义一个 委托类型  delegate void MyDel(); 
// new MyDel(myInstObj.mem_func);
// new MyDel(SClass.otherM2);
// del1 = myInstObj.MyM1;
// del2 = SClass.otherM2
// 委托运算 ： 赋值 组合 增加+=  移出-=
// 委托调用（参数）： 加上 even 只有这个成员函数调用
// 系统封装委托 类 Action


