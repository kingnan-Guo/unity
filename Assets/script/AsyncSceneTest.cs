using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneTest : MonoBehaviour
{
    // 声明一个异步操作变量
    AsyncOperation operation;// 声明一个异步操作变量
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AsyncSceneTest");

        
        // 调用异步加载场景的方法
        StartCoroutine(LoadSceneAsync());
    }

    // 协程方法来异步加载场景
    IEnumerator LoadSceneAsync()
    {
        // 创建一个异步操作，用于加载场景
        operation = SceneManager.LoadSceneAsync("myScenes");
        operation.allowSceneActivation = false; // 禁止场景自动激活
        // yield return new WaitForSeconds(5); // 等待5秒
        yield return operation; // 等待异步操作完成
    }
    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        if (time > 5){
            operation.allowSceneActivation = true; // 允许场景自动激活
        }
        Debug.Log(operation.progress);
    }
}