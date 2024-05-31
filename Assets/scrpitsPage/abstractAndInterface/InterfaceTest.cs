using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 强制子类 实现这个接口
public interface shape
{
    // 不要写权限 默认 是 public
    void draw();// 要求继承了这个接口的子类 必须要实现这个方法；
}

class rect_shape : shape
{
    // 编译器的角度强制要求是现这个方法
    public void draw(){
        Debug.Log("rect_shape 子类的 draw");
    }
}
public class InterfaceTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        shape s = new rect_shape();
        s.draw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/**
 * // interface
 接口使用  interface 关键字声明 ， 它与类的声明类似，接口声明默认是 public 的，接口不能包含 常量、 字段、运算符、 实例构造函数、析构函数或者类型；
 接口可以包含抽象方法、 静态方法、 事件、 索引器、 属性、 命名空间、 类、 委托、 枚举和结构；
 接口不能被实例化， 接口可以被类、 结构、 委托和枚举实现；
 接口可以继承多个接口；
 接口成员自动成为 public 的， 不能包含任何访问权限 修饰符；
 成员也不能是静态成员

 接口成员不能被 private 或 protected 修饰；
 接口成员不能被 static 或 virtual 修饰；
 接口成员不能被 abstract 修饰；
 接口成员不能被 sealed 修饰；
 接口成员不能被 extern 修饰；

子类必须要强制实现这个接口，否则编译器会报错

 *
 */


 


 