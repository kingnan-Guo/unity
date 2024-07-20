using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class WebRequestSkipCertificate : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}

public class getHttpMap : MonoBehaviour
{

    private AssetBundle mianAB = null;
    private AssetBundleManifest manifest = null;

    private Dictionary<string, AssetBundle> ABDic = new Dictionary<string, AssetBundle>();

    // string url = "http://10.54.62.221:8099/scf/static/unity3d/StreamingAssets/WebGL/WebGL/"; 
    // string pathUrl = "http://10.54.62.221:8099/scf/static/unity3d/StreamingAssets/WebGL/";
    // string url = "http://127.0.0.1:5500/Assets/StreamingAssets/StandaloneWindows/StandaloneWindows";
    // string pathUrl = "http://127.0.0.1:5500/Assets/StreamingAssets/StandaloneWindows/";

    string url = "http://127.0.0.1:5500/Assets/StreamingAssets/StandaloneWindows/StandaloneWindows";
    string pathUrl = "http://127.0.0.1:5500/Assets/StreamingAssets/StandaloneWindows/";

    // string url = "https://cloud.wisualarm.com/static/unity3d/StreamingAssets/WebGL/WebGL";
    // string pathUrl = "https://cloud.wisualarm.com/static/unity3d/StreamingAssets/WebGL/";
    
    // string url = "https://onlinetest.wisualarm.com/alarm/static/unity3d/StreamingAssets/WebGL/WebGL";
    // string pathUrl = "https://onlinetest.wisualarm.com/alarm/static/unity3d/StreamingAssets/WebGL/";



    // string url = "http://10.56.21.101:883/alarm/static/unity3d/StreamingAssets/WebGL/WebGL";
    // string pathUrl = "http://10.56.21.101:883/alarm/static/unity3d/StreamingAssets/WebGL/";

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
    }

    IEnumerator getMaps(){


        // string url = "http://yourapi.com/endpoint";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.certificateHandler = new WebRequestSkipCertificate();
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
            //     // AssetBundle.LoadFromFile("http://127.0.0.1:5501/Assets/StreamingAssets/WebGL/WebGL");
            // }

            AssetBundle dependAB = null;           
            for(int i = 0; i < dependABNameArr.Length; i++){
                string dependABPath = pathUrl + dependABNameArr[i];

                Debug.Log("dependABPath =="+dependABPath);

                UnityWebRequest dependABPathwebRequest = UnityWebRequest.Get(dependABPath);
                dependABPathwebRequest.certificateHandler = new WebRequestSkipCertificate();

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
            ABPathwebRequest.certificateHandler = new WebRequestSkipCertificate();

            yield return ABPathwebRequest.SendWebRequest();

            AssetBundle ABD = AssetBundle.LoadFromMemory(ABPathwebRequest.downloadHandler.data);
            GameObject go = ABD.LoadAsset<GameObject>("Assets/resources/dahuyuahqu.prefab");
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
        // UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("http://127.0.0.1:5501/Assets/StreamingAssets/WebGL/WebGL");
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










    IEnumerator getTreeMaps(){


        // string url = "http://127.0.0.1:5501/WebGL/WebGL"; 
        // string pathUrl = "http://127.0.0.1:5501/WebGL/";
        // string url = "http://10.54.62.221:8099/scf/static/unity3d/StreamingAssets/WebGL/WebGL"; 
        // string pathUrl = "http://10.54.62.221:8099/scf/static/unity3d/StreamingAssets/WebGL/";

        // string url = "http://yourapi.com/endpoint";



            string[] dependABNameArr = manifest.GetAllDependencies("treemap");

            Debug.Log("dependABNameArr =="+dependABNameArr.Length);
            // 加载 依赖包
            // for(int i = 0; i < dependABNameArr.Length; i++){
            //     Debug.Log("dependABNameArr[i] =="+dependABNameArr[i]);
            //     // AssetBundle.LoadFromFile("http://127.0.0.1:5501/Assets/StreamingAssets/WebGL/WebGL");
            // }

            // AssetBundle dependAB = null;           
            for(int i = 0; i < dependABNameArr.Length; i++){
                string dependABPath = pathUrl + dependABNameArr[i];

                // Debug.Log("dependABPath =="+dependABPath);

                UnityWebRequest dependABPathwebRequest = UnityWebRequest.Get(dependABPath);
                dependABPathwebRequest.certificateHandler = new WebRequestSkipCertificate();

                yield return dependABPathwebRequest.SendWebRequest();

                AssetBundle dependABPathab = AssetBundle.LoadFromMemory(dependABPathwebRequest.downloadHandler.data);
    

            }


            UnityWebRequest ABPathwebRequest = UnityWebRequest.Get(pathUrl+"treemap");
            ABPathwebRequest.certificateHandler = new WebRequestSkipCertificate();

            yield return ABPathwebRequest.SendWebRequest();

            AssetBundle ABD = AssetBundle.LoadFromMemory(ABPathwebRequest.downloadHandler.data);
            GameObject go = ABD.LoadAsset<GameObject>("Assets/resources/tree.prefab");
            GameObject goi = GameObject.Instantiate(go);
            goi.transform.position = new Vector3(-7.26f, -4.2f, -4.22f);
            // goi.transform.localScale = new Vector3(1,1,1);





        //  StartCoroutine(getTerrainMaps());


    }


    IEnumerator getTerrainMaps(){


        // string url = "http://127.0.0.1:5501/WebGL/WebGL"; 
        // string pathUrl = "http://127.0.0.1:5501/WebGL/";
        // string url = "http://10.54.62.221:8099/scf/static/unity3d/StreamingAssets/WebGL/WebGL"; 
        // string pathUrl = "http://10.54.62.221:8099/scf/static/unity3d/StreamingAssets/WebGL/";

        // string url = "http://yourapi.com/endpoint";



            string[] dependABNameArr = manifest.GetAllDependencies("terrain");

            Debug.Log("terrain dependABNameArr =="+dependABNameArr.Length);
            // 加载 依赖包
            // for(int i = 0; i < dependABNameArr.Length; i++){
            //     Debug.Log("dependABNameArr[i] =="+dependABNameArr[i]);
            //     // AssetBundle.LoadFromFile("http://127.0.0.1:5501/Assets/StreamingAssets/WebGL/WebGL");
            // }

            // AssetBundle dependAB = null;           
            for(int i = 0; i < dependABNameArr.Length; i++){
                string dependABPath = pathUrl + dependABNameArr[i];

                // Debug.Log("dependABPath =="+dependABPath);

                UnityWebRequest dependABPathwebRequest = UnityWebRequest.Get(dependABPath);
                dependABPathwebRequest.certificateHandler = new WebRequestSkipCertificate();

                yield return dependABPathwebRequest.SendWebRequest();

                AssetBundle dependABPathab = AssetBundle.LoadFromMemory(dependABPathwebRequest.downloadHandler.data);
    

            }


            UnityWebRequest ABPathwebRequest = UnityWebRequest.Get(pathUrl+"terrain");
            ABPathwebRequest.certificateHandler = new WebRequestSkipCertificate();

            yield return ABPathwebRequest.SendWebRequest();

            AssetBundle ABD = AssetBundle.LoadFromMemory(ABPathwebRequest.downloadHandler.data);
            GameObject go = ABD.LoadAsset<GameObject>("Assets/resources/Terrain.prefab");
            GameObject goi = GameObject.Instantiate(go);
            goi.transform.position = new Vector3(-2701f, -0.1f, -2529f);
            // goi.transform.localScale = new Vector3(1,1,1);








    }





}
