using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using first;
// using two; // 取消注释 会报错

// 模板
class MyPoint<T>{
    public T x;
    public T y;

    public T getData(){
        return this.x;
    }
}

namespace first
{
    class namespace_item{
        public int x;
        public void getData(){
            Debug.Log("namespace first "+ x);
        }
    }
}


namespace two
{
    class namespace_item{
        public int x;

        public void getData(){
            Debug.Log("namespace two "+ x);
        }
    }
}

public class genericity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyPoint<int> my_p = new MyPoint<int>();
        my_p.x = 5;
        int a = my_p.getData();
        Debug.Log(a);
        

        first.namespace_item item = new first.namespace_item();
        item.x = 0;
        item.getData();

        // 在 using 里查找
        namespace_item i = new namespace_item();
        i.getData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// 泛型
