using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// 引入场景管理器

public class changeSceneTest : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {

        this.Invoke("changeScene", 5f);// 5秒后调用changeScene方法
    }
    void changeScene()
    {
        SceneManager.LoadScene("myNewScene");// 加载场景
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  

}
//  场景切换 
