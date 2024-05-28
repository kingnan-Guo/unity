using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class NetworkTest : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(GetJsonData());
    }

    IEnumerator GetJsonData()
    {
        // string url = "http://example.com/api/data"; // 替换为您的API接口地址
        string url = "https://124.160.108.62/evo-apigw/evo-brm/version";

        // 创建一个Unity的WebRequest对象
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        // 发送请求并等待返回结果
        yield return webRequest.SendWebRequest();

        // 检查是否有错误
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error: " + webRequest.error);
        }
        else
        {
            // 如果请求成功，从接口响应中获取JSON数据
            string json = webRequest.downloadHandler.text;

            // 打印JSON数据
            Debug.Log(json);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
