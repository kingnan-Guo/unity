using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wwwTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getHttp());
    }


    IEnumerator getHttp(){
        // string url = "https://27.128.246.227:10443/evo-apigw/evo-brm/1.2.0/config/get-version";
        string url = "https://www.baidu.com";
        WWW w = new WWW(url);
        yield return null;
        Debug.Log(w.text);
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
