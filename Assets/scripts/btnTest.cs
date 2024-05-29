using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using UnityEngine.UI;


//这里的类WebReqSkipCert 继承了CertificateHandler 然后仅重写了ValidateCertificate(byte[] certificateData)函数让其永远返回true，实现跳过ssl验证的功能。
public class WebReqSkipCert : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}


public class btnTest : MonoBehaviour
{

    private  Text Texter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void btnClick(){
        Debug.Log("click");
        // StartCoroutine(GetJsonData());
        // Text textComponent = GetComponent<Text>();
        // textComponent.text = "data2";
        // Text textComponent = GetComponent<Text>();

        // Debug.Log("textComponent ="+ textComponent);

        // Debug.Log(gameObject.name);

        // Text text = gameObject.GetComponentInChildren<Text>();
        // Text[] texts = gameObject.GetComponentsInChildren<Text>();
        // foreach (Text text in texts)
        // {
        //     Debug.Log("Text found: " + text.text);
        // }

        // Image text = gameObject.GetComponent<Image>();
        // Debug.Log("text ="+ text);

        // Text text =GameObject.Find("Canvas/Text").GetComponent(UI.Text);


        // Text text = gameObject.GetComponent<Text>();
        // Debug.Log("text ="+ text.text);
        // gameObject.GetComponent<Text>().text = "data2";

        // 创建一个新的GameObject
        GameObject newTextObject = new GameObject("NewText");
        
        // 添加Text组件
        Text newTextComponent = newTextObject.AddComponent<Text>();
        
        // 设置文本内容
        newTextComponent.text = "Hello, World!";
        
        // 设置字体、字号、颜色等样式属性
        // newTextComponent.font = Resources.GetBuiltinResource<Font>("Anton.ttf");
        newTextComponent.fontSize = 24;
        newTextComponent.color = Color.white;
        
        // 将Text组件添加到Canvas或其他UI容器中
        newTextObject.transform.SetParent(gameObject.transform, false);



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
}
