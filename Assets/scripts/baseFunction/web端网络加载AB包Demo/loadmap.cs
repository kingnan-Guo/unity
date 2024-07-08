using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class loadmap : MonoBehaviour
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



public class loadmap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getMaps());
        // StartCoroutine(getMaps2());
        this.Invoke("StartCoroutineFunction", 5.0f);
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
        string url = "http://127.0.0.1:5500/AssetBundles/StandaloneWindows64_2/dahuamap";   
        WWW w = new WWW(url);
        yield return w;
        // Debug.Log(w);
        Debug.Log("success");
        AssetBundle ab = w.assetBundle;
        Debug.Log("ab =="+ab);
 
        GameObject go = ab.LoadAsset<GameObject>("Assets/dahuyuahqu1.fbx");
        GameObject.Instantiate(go);





    }
    IEnumerator getMaps2(){
        string url = "http://127.0.0.1:5500/AssetBundles/StandaloneWindows64_2/dahuamate";           
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

}
