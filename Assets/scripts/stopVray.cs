using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;
 
[Preserve]//特性，防止在打包的时候这个脚本 没有被打包进程序
public class StopVray
{
    // //在启动画面显示之前执行这个方法
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    // private static void Test()
    // {
        
    //     Task.Run(() =>
    //     {
    //         Debug.Log("aabbccddeeffgg");
    //         SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
    //     });
    // }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    static void OnBeforeSplashScreen()
    {
        Debug.Log("kingnan = Before SplashScreen is shown and before the first scene is loaded.");
    }
 
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoad()
    {
        Debug.Log("kingnan = First scene loading: Before Awake is called.");
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoad()
    {
        Debug.Log("kingnan = First scene loaded: After Awake is called.");
    }
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeInitialized()
    {
        Debug.Log("kingnan = Runtime initialized: First scene loaded: After Awake is called.");
    }









}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class stopVray : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
