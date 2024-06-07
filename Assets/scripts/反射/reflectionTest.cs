using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;


class TestClass{
    private int a = 1;
    public string b = "2";

    public TestClass(){
        Debug.Log("执行构造函数 TestClass");
    }

    public TestClass(int i){
        this.a = i;
        Debug.Log("执行构造函数 TestClass(int i) ="+ i);
    }

    public TestClass(int i, string b):this(i){
        this.b = b;
        Debug.Log("执行构造函数 TestClass(int i, string b) = "+ b +" i = "+ i);
    }

    public void print(int c){
        Debug.Log("print a = " + this.a + " b = " + this.b);
        Debug.Log("print c = " + c);
    }

    public static implicit operator TestClass(Type v)
    {
        throw new NotImplementedException();
    }
}

public class reflectionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int c = 3;
        Type type = c.GetType();
        Debug.Log(type);
        Debug.Log(type.Name);
        Debug.Log(type.FullName);
        Debug.Log("type.Assembly ="+type.Assembly);

        Type typeInt = typeof(int);
        Debug.Log("typeInt =" + typeInt);

        Type typeInt32 = Type.GetType("System.Int32");
        Debug.Log("typeInt32 =" + typeInt32);


        Type TestClassType = typeof(TestClass);
        Debug.Log(TestClassType);




        Type[] types = TestClassType.GetInterfaces();
        foreach (var item in types)
        {
            Debug.Log("GetInterfaces =" +item);
        }


        #region 获取类中的所有公共成员
        Type typeTestClass = typeof(TestClass);
        // 得到所有的公共 成员
        // 需要引用 命名空间
        MemberInfo[] memberInfos = typeTestClass.GetMembers();
        foreach (var item in memberInfos)
        {
            Debug.Log("GetMembers = " + item);
        }
        #endregion



        #region 获取类中的所有公共成员构造函数并调用
        ConstructorInfo[] constructorInfo = typeTestClass.GetConstructors();
        foreach (var item in constructorInfo)
        {
            Debug.Log("GetConstructors = " + item);
        }
        
        // //获取一个构造函数 并执行 得到构造函数 传输type 数组
        ConstructorInfo cotrInfo = typeTestClass.GetConstructor(new Type[0]);
        //执行构造函数
        TestClass obj = cotrInfo.Invoke(null) as TestClass;
        Debug.Log("cotrInfo = " + obj);



        ConstructorInfo cotrInfo1 = typeTestClass.GetConstructor(new Type[] { typeof(int) });
        //执行构造函数
        obj = cotrInfo1.Invoke(new object[] { 2 }) as TestClass;
        Debug.Log("cotrInfo = " + obj);

        ConstructorInfo cotrInfo2 = typeTestClass.GetConstructor(new Type[] { typeof(int), typeof(string)});
        //执行构造函数
        obj = cotrInfo2.Invoke(new object[] { 2, "stringParams" }) as TestClass;
        Debug.Log("cotrInfo = " + obj);


        #endregion



        #region 获取类中的所有公共成员变量
        FieldInfo[] fieldInfos = typeTestClass.GetFields();
        foreach (var item in fieldInfos)
        {
            Debug.Log("GetFields = " + item);
        }

        // 得到 指定名称的你公共成员 变量
        FieldInfo fieldInfo_b = typeTestClass.GetField("b");
        Debug.Log("fieldInfo_b = " + fieldInfo_b);

        TestClass objTestClass = new TestClass();
        objTestClass.b = "10";


        // 通过 反射 获取 对象 的 某个 变量
        string b = fieldInfo_b.GetValue(objTestClass) as string;
        Debug.Log("objTestClass.b = " + b);

        // 通过 反射 设置 对象 的 某个 变量
        fieldInfo_b.SetValue(objTestClass, "100");
        Debug.Log("objTestClass.b = " + objTestClass.b);


        #endregion





        #region 获取类中的所有公共成员方法


        // eg:
        Type stringType = typeof(string);
        MethodInfo[] stringType_methods = stringType.GetMethods();
        foreach (var item in stringType_methods)
        {
            Debug.Log("GetMethods stringType_methods = " + item);
        }

        //获取 截取字符串的 方法
        MethodInfo methodInfo_Substring = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
        Debug.Log("methodInfo_Substring = " + methodInfo_Substring);
        
        string str = "123456789";
        object result = methodInfo_Substring.Invoke(str, new object[] { 1, 3 });
        Debug.Log("result = " + result);



        // 得到 指定名称的 公共成员方法 
        MethodInfo[] methodInfos = typeTestClass.GetMethods();
        foreach (var item in methodInfos)
        {
            Debug.Log("typeTestClass GetMethods = " + item);
        }

        MethodInfo methodInfo_print = typeTestClass.GetMethod("print", new Type[]{typeof(int)});
        methodInfo_print.Invoke(objTestClass, new object[] { 10 });

        // 得到 指定名称的 公共成员方法

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
