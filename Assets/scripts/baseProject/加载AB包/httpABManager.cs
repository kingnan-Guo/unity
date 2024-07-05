// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class httpABManager : MonoBehaviour
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class httpABManager : SingletonAutoMono<httpABManager>
{


    // 字典存储 加载的 AB 包
    private Dictionary<string, AssetBundle> ABDic = new Dictionary<string, AssetBundle>();


    // 主包
    private AssetBundle mianAB = null;
    // 依赖包的 获取用的配置文件 
    private AssetBundleManifest manifest = null;
    // 依赖包
    private List<AssetBundle> dependABList = new List<AssetBundle>();







    /// <summary>
    /// 异步 加载AB包
    /// </summary>
    /// <param name="path"></param>
    /// <param name="callback"></param>
    public void LoadResAsync(string ABName, string resName, UnityAction<Object> callback){
        // 启动协程
        StartCoroutine(ReallyLoadResAsync(ABName, resName, callback));
    }




    private IEnumerator ReallyLoadResAsync(string ABName, string resName, UnityAction<Object> callback){
        // loadAB(ABName);
        // 指定类型 
        AssetBundleRequest assetBundleRequest = ABDic[ABName].LoadAssetAsync(resName);
        yield return assetBundleRequest;

        // if(assetBundleRequest.asset == null){
        // }

        if(assetBundleRequest.asset is GameObject){
            callback(GameObject.Instantiate(assetBundleRequest.asset));
        } else {
            callback(assetBundleRequest.asset);
        }
    }




    public void LoadResAsync(string ABName, string resName, System.Type type, UnityAction<Object> callback) 
    {
        // 启动协程
        StartCoroutine(ReallyLoadResAsync(ABName, resName, type, callback));
    }

    private IEnumerator ReallyLoadResAsync(string ABName, string resName, System.Type type, UnityAction<Object> callback)
    {
        // loadAB(ABName);
        // 指定类型 
        AssetBundleRequest assetBundleRequest = ABDic[ABName].LoadAssetAsync(resName, type);
        yield return assetBundleRequest;
        // if(assetBundleRequest.asset == null){
        // }
        if(assetBundleRequest.asset is GameObject){
            callback(GameObject.Instantiate(assetBundleRequest.asset) );
        } else {
            callback(assetBundleRequest.asset);
        }
    }




    public void LoadResAsync<T>(string ABName, string resName, UnityAction<T> callback) where T: Object
    {
        // 启动协程
        StartCoroutine(ReallyLoadResAsync<T>(ABName, resName, callback));
    }

    private IEnumerator ReallyLoadResAsync<T>(string ABName, string resName, UnityAction<T> callback) where T : Object{
        // loadAB(ABName);
        // 指定类型 
        AssetBundleRequest assetBundleRequest = ABDic[ABName].LoadAssetAsync<T>(resName);
        yield return assetBundleRequest;

        if(assetBundleRequest.asset is GameObject){
            callback(GameObject.Instantiate(assetBundleRequest.asset as T));
        } else {
            callback(assetBundleRequest.asset as T);
        }
    }




}
