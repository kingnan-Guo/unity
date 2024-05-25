using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 游戏数据 文件路径 只读 加密压缩
        Debug.Log(Application.dataPath);
        // 持久化文件夹路径
        Debug.Log(Application.persistentDataPath);
        // StreamingAssets 文件夹 路径 只读 配置文件
        Debug.Log(Application.streamingAssetsPath);
        // 临时文件
        Debug.Log(Application.temporaryCachePath);
        // 控制是否在后台运行
        Debug.Log(Application.runInBackground);
        // 打开 URL
        Application.OpenURL("https://github.com/");
        // 退出 游戏
        // Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
