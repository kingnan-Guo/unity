using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAndSet : MonoBehaviour
{

    private int _value;

    struct myStruct<T>{
        public int a;
        public string b;
        public T C;
        public void test(){
            Debug.Log("C ="+ C);
        }
        public myStruct(int a, string b, T C){
            this.a = a;
            this.b = b;
            this.C = C;
        }
    }

    class  person{
        myStruct<string> v2;// 这里的结构体 会随着 new persong 存放在 堆上
    }

    public int value {
        get {
            Debug.Log("get" +_value);
            return this._value;
        }
        set {
            this._value = value;
        }
    }

    void copyStruct_function(myStruct<int> data){
        Debug.Log("复制了一份内存的 结构体" + data.a);
    }

    void red_Struct_function(ref myStruct<int> data){
        Debug.Log("直接引用了传过来的 结构体" + data.a);
    }


    // Start is called before the first frame update
    void Start()
    {
        this.value = 999;
        Debug.Log("value ="+ this.value);

        person p; // 引用变量 存放在 栈上

        p = new person();// new 出来的在 堆上； p 在栈上 存类 堆上 的 引用，也就是 堆上的地址



        // 结构图 ======
        myStruct<int> myStruct1;// 分配在栈的上的 结构体实例
        myStruct1.a = 1;
        myStruct1.b = "sss";
        myStruct1.C = 77;

        myStruct<int> v = new myStruct<int>(1, "www", 2);// 与 myStruct<int> myStruct1 一样


        copyStruct_function(myStruct1);

        // 加上 ref  是引用
        red_Struct_function(ref myStruct1);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


// 结构体 与 类的区别
// 1、局部变量  和 参数 变量 内存分配的 内存段 --》 .net 栈 ； 释放： 函数 返回以后 释放 函数 在栈
// 2、动态内存对象， new 出来的 对象的 实例 ，是从 内存分配的内存段  -》.net 堆 上 分配出来 ；  释放 ： 没有引用变量只想这段内存的时候， 自动回收释放
