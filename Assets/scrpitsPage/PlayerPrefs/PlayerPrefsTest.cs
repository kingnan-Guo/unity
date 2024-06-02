using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 保存 用户名称 到本地
        String userName = PlayerPrefs.GetString("userName");
        if (userName.Equals("")){
            userName = "kingnan";
            
            PlayerPrefs.SetString("userName", userName);
            Debug.Log("存储 userName: " + userName);
        } else {
            Debug.Log("获取 userName: " + userName);

        }

        this.Invoke("DelectPlayerPrefs", 5.0f);

        
    }


    void DelectPlayerPrefs()
    {
        Debug.Log("DelectPlayerPrefs");
        PlayerPrefs.DeleteAll();
        // PlayerPrefs.DeleteKey("userName");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

// 本地存储 的全局对象是、
// PlayerPrefs.SetInt("highScore", 9000);
// int highScore = PlayerPrefs.GetInt("highScore");
// Debug.Log("High Score: " + highScore);   
// PlayerPrefs.DeleteKey("highScore");

// 本地存储 的key 和 value 
