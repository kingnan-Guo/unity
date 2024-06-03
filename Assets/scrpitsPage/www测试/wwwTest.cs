using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wwwTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getMaps());

        this.Invoke("StartCoroutineFunction", 5.0f);
        // 延时3s

        // StartCoroutine(getMaps());
    }

    void  StartCoroutineFunction(){
        StartCoroutine(getMaps2());
    }


    IEnumerator getHttp(){
        // string url = "https://27.128.246.227:10443/evo-apigw/evo-brm/1.2.0/config/get-version";
        string url = "https://www.baidu.com";
        WWW w = new WWW(url);
        yield return null;
        Debug.Log(w.text);
        

    }


    IEnumerator getHttp2(){
        // string url = "https://27.128.246.227:10443/evo-apigw/evo-brm/1.2.0/config/get-version";
        string url = "https://www.baidu.com";           
        WWWForm form = new WWWForm();
            
        form.AddField("name", "value");
        WWW w = new WWW(url, form);
        yield return null;
        Debug.Log(w.text);
    }

    // 加载 三位模型
    IEnumerator getMaps(){
        string url = "http://127.0.0.1:5500/static/dahua_map";           
        WWW w = new WWW(url);
        yield return w;
        // Debug.Log(w);
        Debug.Log("success");
        AssetBundle ab = w.assetBundle;
        Debug.Log(ab);
 
        GameObject go = ab.LoadAsset<GameObject>("Assets/resources/dahuyuahqu.fbx");
        GameObject.Instantiate(go);


    }

    

    IEnumerator getMaps2(){
        string url = "http://127.0.0.1:5500/static/dahua2";           
        WWW w = new WWW(url);
        yield return w;
        // Debug.Log(w);
        Debug.Log("success");
        AssetBundle ab = w.assetBundle;
        Debug.Log(ab);
 
        GameObject go = ab.LoadAsset<GameObject>("Assets/resources/dahu2.fbx");
        GameObject.Instantiate(go);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
