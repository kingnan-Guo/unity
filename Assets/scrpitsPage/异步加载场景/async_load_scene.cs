using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class async_load_scene : MonoBehaviour
{
    AsyncOperation async_operation;
    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene("scene_name");

        StartCoroutine(aysnc_load_scene());
    }

    IEnumerator aysnc_load_scene(){
        this.async_operation = SceneManager.LoadSceneAsync("my_aysnc_scene");
        this.async_operation.allowSceneActivation = false;
        yield return null;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.async_operation.progress);
        if(this.async_operation.progress >= 0.9f){
            this.async_operation.allowSceneActivation = true;
        }
    }
}
