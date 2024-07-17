using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Security.Cryptography.X509Certificates;
 


class datajson {
  bool success;
  string code;
  string errMsg;
}
/// <summary>
/// 跳过Web请求证书避免出现 报错：【SSL CA certificate error】 与 【Curl error 60: Cert verify failed: UNITYTLS_X509VERIFY_FLAG_USER_ERROR1】
/// </summary>
public class WebRequestSkipCertificateIgnore : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}

public class IgnoreCertificateExample : MonoBehaviour
{
    IEnumerator Start()
    {
        // UnityWebRequest  webRequest = new UnityWebRequest("https://10.56.21.135/evo-apigw/evo-brm/version", "GET");


        //实现跳过ssl验证
        // webRequest.certificateHandler = new WebRequestSkipCertificate();
        // UnityWebRequest  webRequest = new UnityWebRequest("https://www.baidu.com/", "GET");
        
        // string url = "https://10.56.21.135/evo-apigw/evo-brm/version";

        string url = "https://10.56.21.135/scf/static/unity3d_2024/StreamingAssets/WebGL/WebGL";
        // string url = "http://10.54.62.221:8099/evo-apigw/evo-brm/version";

        // string url = "https://www.baidu.com/";
        UnityWebRequest req = UnityWebRequest.Get(url);
        req.certificateHandler = new WebRequestSkipCertificateIgnore();
        // req.SetRequestHeader("Content-Type", "application/json");
        // req.SetRequestHeader("Accept", "application/json");
        yield return req.SendWebRequest();
         Debug.Log(req.downloadHandler.data);


        // 注册一个事件处理程序来处理SSL/TLS证书验证错误
        // 这里我们简单地忽略错误
        // uwr.certificateHandler = new CertificateHandler((sender, certificate, chain, errors) => true);
        // uwr.certificateHandler = new IgnoreCertificateHandler();
        // yield return webRequest.SendWebRequest();
        // Debug.Log(webRequest);
        // Debug.Log("webRequest.downloadHandler =="+ webRequest);
        // string resultContent = System.Text.Encoding.UTF8.GetString(uwr.downloadHandler.data);
        // Debug.Log("Return Content: " + resultContent);


        //  JsonUtility.FromJson<datajson>(resultContent)
        // string jsonResult = webRequest.downloadHandler.text;

        // Debug.Log("webRequest  =  " + jsonResult);

        // Debug.Log(uwr);
        // if (uwr.result != UnityWebRequest.Result.Success)
        // {
        //     Debug.Log(uwr.error);
        // }
        // else
        // {
        //     Debug.Log(uwr.downloadHandler.text);
        // }
    }
}


