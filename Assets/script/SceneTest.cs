using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SceneTest");
        //两个类 场景类 场景管理类
        // 加载 场景
        // SceneManager.LoadScene("myScenes");
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        // 是否被加载
        Debug.Log(scene.isLoaded);
        // 场景路径
        Debug.Log(scene.path);
        // 场景索引
        Debug.Log(scene.buildIndex);

        // 所有的 游戏物体
        GameObject[] gos = scene.GetRootGameObjects();
        Debug.Log(gos);

        

        // 创建新场景
        Scene newScene =SceneManager.CreateScene("newScene");
        // 激活的场景 个数
        Debug.Log(SceneManager.sceneCount);


        // 卸载 这个场景
        // SceneManager.UnloadSceneAsync(newScene);
        
        //LoadSceneMode.Single 简单替换
        // SceneManager.LoadScene("myScenes", LoadSceneMode.Single);
        // Additive 添加 一个场景，两个场景 叠加在一起
        SceneManager.LoadScene("myScenes", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
