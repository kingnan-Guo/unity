using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class getHttpMap : MonoBehaviour
{

    private AssetBundle mianAB = null;
    private AssetBundleManifest manifest = null;

    private Dictionary<string, AssetBundle> ABDic = new Dictionary<string, AssetBundle>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getMaps());
        
        // this.Invoke("StartCoroutineFunction", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void  StartCoroutineFunction(){
        StartCoroutine(getMaps2());
    }

    IEnumerator getMaps(){
        // string url = "http://127.0.0.1:5500/AssetBundles/StandaloneWindows64/buildingmodel";        
        string url = "http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/WebGL"; 
        string pathUrl = "http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/";
        // string url = "http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/dahuamap";
        // WWW w = new WWW(url);
        // yield return w;
        // // Debug.Log(w);
        // Debug.Log("success");
        // AssetBundle ab = w.assetBundle;
        // Debug.Log("ab =="+ab);
 
        // GameObject go = ab.LoadAsset<GameObject>("Assets/dahuyuahqu.fbx");
        // GameObject.Instantiate(go);



        // mianAB = AssetBundle.LoadFromFile(w);
        // //加载 关键依赖 文件
        // manifest = mianAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");


        // string[] dependABNameArr = manifest.GetAllDependencies("Assets/dahuyuahqu.fbx");
        // // 加载 依赖包
        // for(int i = 0; i < dependABNameArr.Length; i++){
        //     Debug.Log("dependABNameArr[i] =="+dependABNameArr[i]);
        //     // AssetBundle.LoadFromFile("http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/WebGL");
        // }






        // string url = "http://yourapi.com/endpoint";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            Debug.Log("success"+ webRequest);

            // Debug.Log("success"+ webRequest.assetBundle);
            AssetBundle ab = AssetBundle.LoadFromMemory(webRequest.downloadHandler.data);
            Debug.Log("UnityWebRequest == "+ab);

            mianAB = ab;
            // GameObject go = ab.LoadAsset<GameObject>("Assets/dahuyuahqu.fbx");
            // GameObject.Instantiate(go);

            // mianAB = AssetBundle.LoadFromFile(ab);
            //加载 关键依赖 文件
            manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");


            string[] dependABNameArr = manifest.GetAllDependencies("dahuamap");

            Debug.Log("dependABNameArr =="+dependABNameArr.Length);
            // 加载 依赖包
            // for(int i = 0; i < dependABNameArr.Length; i++){
            //     Debug.Log("dependABNameArr[i] =="+dependABNameArr[i]);
            //     // AssetBundle.LoadFromFile("http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/WebGL");
            // }

            AssetBundle dependAB = null;           
            for(int i = 0; i < dependABNameArr.Length; i++){
                string dependABPath = pathUrl + dependABNameArr[i];

                Debug.Log("dependABPath =="+dependABPath);

                UnityWebRequest dependABPathwebRequest = UnityWebRequest.Get(dependABPath);

                yield return dependABPathwebRequest.SendWebRequest();

                AssetBundle dependABPathab = AssetBundle.LoadFromMemory(dependABPathwebRequest.downloadHandler.data);
    
                // 判断 包是否被加载过
                // if(!ABDic.ContainsKey(dependABNameArr[i])){
                //     // 加载 依赖包
                //     dependAB = AssetBundle.LoadFromMemory(dependABPath);

                //     // dependABmanifest = dependAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                //     // Debug.Log("dependABmanifest =="+ dependABmanifest);
                //     // // 加载 依赖包 中的 资源
                //     // string[] dependResNameArr = dependABmanifest.GetAllAssetBundles();
                //     // for(int j = 0; j < dependResNameArr.Length; j++){
                //     //     Debug.Log("dependResNameArr =="+ dependResNameArr[j]);
                //     //     // string dependResPath = pathUrl + dependResNameArr[j];
                //     //     // 加载 依赖包 中的 资源
                //     //     // dependAB = AssetBundle.LoadFromFile(dependResPath);
                //     // }
                //     // 存入 依赖包
                //     // 存入 字典
                //     ABDic.Add(dependABNameArr[i], dependAB);
                // }
            }


            UnityWebRequest ABPathwebRequest = UnityWebRequest.Get(pathUrl+"dahuamap");

            yield return ABPathwebRequest.SendWebRequest();

            AssetBundle ABD = AssetBundle.LoadFromMemory(ABPathwebRequest.downloadHandler.data);
            GameObject go = ABD.LoadAsset<GameObject>("Assets/prefab/dahuyuahqu.prefab");
            GameObject goi = GameObject.Instantiate(go);
            goi.transform.position = new Vector3(0,0,0);
            // goi.transform.localScale = new Vector3(1,1,1);


            // Debug.Log("obj.transform.childCount =="+ goi.transform.childCount);
            for (int i = 0; i < goi.transform.childCount; i++)
            {

                // Debug.Log("go.transform.GetChild(i).name =="+ goi.transform.GetChild(i).name);
                if(goi.transform.GetChild(i).name.Contains("floor")){
                    goi.transform.GetChild(i).tag ="building";
                }
            }

            JsonDataManagerDemo.getInstance();

            // if(!ABDic.ContainsKey(ABName)){
            //     /// 加载 资源 来源包;目标包
            //     AssetBundle ab = AssetBundle.LoadFromFile(pathUrl + ABName);
            //     // Debug.Log("ab =="+ ab);
            //     // GameObject.Instantiate(ab);
            //     ABDic.Add(ABName, ab);
            // }

            StartCoroutine(getTreeMaps());
        }
    }


    IEnumerator GetAssetBundle(string url) {
        // UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/WebGL");
        // yield return www.SendWebRequest();
 
        // if (www.result != UnityWebRequest.Result.Success) {
        //     Debug.Log(www.error);
        // }
        // else {
        //     AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            
        //     GameObject prefab = bundle.LoadAsset<GameObject>("Assets/dahuyuahqu.fbx");
        //     GameObject.Instantiate(prefab);
        // }


        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();


            if (webRequest.result != UnityWebRequest.Result.Success) {
                Debug.Log(webRequest.error);
            }
            else {
                
            }

        }



    }




    IEnumerator getMaps2(){
        string url = "http://127.0.0.1:5500/StreamingAssets/dahuamate";           
        WWW w = new WWW(url);
        yield return w;
        // Debug.Log(w);
        Debug.Log("success");
        AssetBundle ab = w.assetBundle;
        Debug.Log("getMaps2"+ab);

        // "Assets/textures 1/Grass004_1K-JPG/Grass004_1K-JPG_NormalGL.jpg"
        // "Assets/textures/c.jpg"
        // "Assets/textures/\u5899\u9762.jpg"
        // "Assets/textures 1/\u6591\u9A6C\u7EBF.png"
        // "Assets/textures 1/gcz18901.JPG"
        // "Assets/textures 1/Grass004_1K-JPG/Grass004_1K-JPG_Color.jpg
        // "Assets/\u74F7\u7816\u8D34\u56FE (2).png"

        ab.LoadAsset<GameObject>("Assets/textures/\u95E8.jpg");
        ab.LoadAsset<GameObject>("Assets/textures 1/Grass004_1K-JPG/Grass004_1K-JPG_NormalGL.jpg");
        ab.LoadAsset<GameObject>("Assets/textures/c.jpg");
        ab.LoadAsset<GameObject>("Assets/textures/\u5899\u9762.jpg");
        ab.LoadAsset<GameObject>("Assets/textures 1/\u6591\u9A6C\u7EBF.png");
        ab.LoadAsset<GameObject>("Assets/textures 1/gcz18901.JPG");
        ab.LoadAsset<GameObject>("Assets/textures 1/Grass004_1K-JPG/Grass004_1K-JPG_Color.jpg");
        ab.LoadAsset<GameObject>("Assets/\u74F7\u7816\u8D34\u56FE (2).png");


    }






    IEnumerator getTreeMaps(){


        string url = "http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/WebGL"; 
        string pathUrl = "http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/";


        // string url = "http://yourapi.com/endpoint";



            string[] dependABNameArr = manifest.GetAllDependencies("treemap");

            Debug.Log("dependABNameArr =="+dependABNameArr.Length);
            // 加载 依赖包
            // for(int i = 0; i < dependABNameArr.Length; i++){
            //     Debug.Log("dependABNameArr[i] =="+dependABNameArr[i]);
            //     // AssetBundle.LoadFromFile("http://127.0.0.1:5500/Assets/StreamingAssets/WebGL/WebGL");
            // }

            // AssetBundle dependAB = null;           
            for(int i = 0; i < dependABNameArr.Length; i++){
                string dependABPath = pathUrl + dependABNameArr[i];

                // Debug.Log("dependABPath =="+dependABPath);

                UnityWebRequest dependABPathwebRequest = UnityWebRequest.Get(dependABPath);

                yield return dependABPathwebRequest.SendWebRequest();

                AssetBundle dependABPathab = AssetBundle.LoadFromMemory(dependABPathwebRequest.downloadHandler.data);
    

            }


            UnityWebRequest ABPathwebRequest = UnityWebRequest.Get(pathUrl+"treemap");

            yield return ABPathwebRequest.SendWebRequest();

            AssetBundle ABD = AssetBundle.LoadFromMemory(ABPathwebRequest.downloadHandler.data);
            GameObject go = ABD.LoadAsset<GameObject>("Assets/prefab/treemap.prefab");
            GameObject goi = GameObject.Instantiate(go);
            goi.transform.position = new Vector3(35,0,-20);
            // goi.transform.localScale = new Vector3(1,1,1);








    }

}
