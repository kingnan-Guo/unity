using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABManager : SingletonAutoMono<ABManager>
{


    // 字典存储 加载的 AB 包
    private Dictionary<string, Object> ABDic = new Dictionary<string, Object>();


    // 主包
    private AssetBundle mianAB = null;
    // 依赖包的 获取用的配置文件 
    private AssetBundleManifest manifest = null;
    // 依赖包
    private List<AssetBundle> dependABList = new List<AssetBundle>();
    // 目标包
    private AssetBundle targetAB = null;
    // 目标包中的 资源
    private Object targetRes = null;


    /// <summary>
    /// 主包名
    /// 不同平台 包名 不一样
    /// </summary>
    private string mianABName{
        get{
#if UNITY_IOS
            return "IOS";
#elif UNITY_ANDROID
            return "Android";
#else
            return "StandaloneWindows64";
#endif
        }
    }

    // AB 包方便修改  路径
    private string pathUrl{
        get{
            return Application.streamingAssetsPath + "/StandaloneWindows64/";
            // return "http://127.0.0.1:5500/AssetsBundles/StandaloneWindows64/";
        }
    }



    //// <summary>
    /// 同步 加载AB包
    /// </summary>
    /// <param name="path"></param>
    /// <param name="callback"></param>
    public object LoadRes(string ABName, string resName)
    {
        /// 加载 AB 包
        if(mianAB == null){
            // 加载 主包
            mianAB = AssetBundle.LoadFromFile(pathUrl + mianABName);
            //加载 关键依赖 文件
            manifest = mianAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }

        /// 获取 依赖包的 关系
        string[] dependABNameArr = manifest.GetAllDependencies(ABName);
        // 加载 依赖包
        for(int i = 0; i < dependABNameArr.Length; i++){
            string dependABPath = pathUrl + dependABNameArr[i];
            // AssetBundle dependAB = AssetBundle.LoadFromFile(dependABPath);
            // dependABList.Add(dependAB);

            // 判断 包是否被加载过
            if(!ABDic.ContainsKey(dependABNameArr[i])){
                // 加载 依赖包
                AssetBundle dependAB = AssetBundle.LoadFromFile(dependABPath);
                // 存入 字典
                ABDic.Add(dependABNameArr[i], dependAB);
            }
        }

 

        if(!ABDic.ContainsKey(ABName)){
            /// 加载 资源 来源包;目标包
            AssetBundle ab = AssetBundle.LoadFromFile(pathUrl + ABName);
            // Debug.Log("ab =="+ ab);
            // GameObject.Instantiate(ab);
            ABDic.Add(ABName, ab);
        }
        

        /// 加载 资源
        return (ABDic[ABName] as AssetBundle).LoadAsset(resName);
    }


    /// <summary>
    /// 单个 AB 包卸载
    /// </summary>
    public void unLoad(){

    }


    /// <summary>
    /// 卸载所有AB包
    /// </summary>
    public void unLoadAll(){

    }

    /// <summary>
    /// 异步 加载AB包
    /// </summary>
    /// <param name="path"></param>
    /// <param name="callback"></param>
    public void LoadResAsync(string ABPath, string resPath, System.Action<Object> callback)
    {

    }

}
