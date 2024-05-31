using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 抽象类
    抽象方法不能直接实例化类

 */
public abstract class abstractTestIterm
{
    public void test(){
        Debug.Log("抽象类中的public方法");
    }
    // 抽象方法
    public abstract void abstractMethod();// 不用实现 等着继承的类去 实现

    public abstract int width { get; set; }
}


public class react_item : abstractTestIterm{
    public override void abstractMethod()
    {
        Debug.Log("抽象方法被实现");
    }

    public override int width
    {
        set{
            Debug.Log("抽象类中的set方法");
        }
        
        get{
            return 100;
        }
    }
}



public class abstractTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        abstractTestIterm item = new react_item();
        item.abstractMethod();
        item.test();

        item.width = 20;// 这句会导致卡死

        Debug.Log(item.width);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/**

 * 1.抽象类不能被实例化，只能被继承
 * 2.抽象类可以包含抽象方法，也可以不包含抽象方法   
 * 3.抽象方法必须在抽象类中，抽象类可以没有抽象方法，但抽象类中必须包含抽象方法
 * 4.抽象类可以包含普通方法，也可以不包含普通方法
 * 5.抽象类可以包含静态方法，也可以不包含静态方法
 * 6.抽象类可以包含非静态代码块，也可以不包含非静态代码块
*/

 // 例如：子弹：对玩家照成伤害的接口⋯. 1/ N多中子弹，子弹1，子弹2， 子弹3 …• 
 // 子弹来指向 —-》实例，强制他们实现 对玩家照成伤害的接口； 
 // 基类子弹—-》子类的实例．对玩家照成伤害的接口