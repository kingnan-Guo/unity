using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
class Main{


    // 虚函数
    public void test_function(){
        Debug.Log("Main test_function");
    }

    public virtual void virtual_test_function(){
        Debug.Log("Main virtual test_function");
    }

    public virtual void override_test_function(){
        Debug.Log("Main override_test_function");
    }

}

class sub: Main{

    public  void test_function(){
        Debug.Log("sub test_function");
        base.test_function();
    }
    public void sub_test_function(){
        Debug.Log("sub_test_function");
    }
    public override void override_test_function(){
        Debug.Log("sub override_test_function");
    }

}

class item{
    public string itemData;
    public virtual void  Draw(){
        Debug.Log("item Draw");
    }
}

class itme_2d: item{
    public override void  Draw(){
        Debug.Log("itme_2d Draw");
    }
}

class item_3d: item{
    public override void  Draw(){
        Debug.Log("item_3d Draw");
    }
}


public class classTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        sub subData = new sub();
        subData.test_function();

        Main main = subData;
        // 子调父
        main.test_function();

        // 虚函数 这里会调用 到主函数的 function
        main.virtual_test_function();

        // 子类重载 虚函数 要加上 overwirte 关键字; 这里会调用  到子函数的 function
        main.override_test_function();
        
        // 虚函数 的 作用； 基类 的引用变量 统一来管理不同的子类的实例
        // 使用 基类 item 接收  itme_2d  item_3d 的实例
        item itemInstance = new itme_2d();
        itemInstance.Draw();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
