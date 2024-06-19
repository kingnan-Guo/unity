using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadABDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        object obj = ABManager.GetInstance().LoadRes("dahuamap", "dahuamate");

        Debug.Log(obj);
        // GameObject.Instantiate(obj);

        // Debug.Log(Application.streamingAssetsPath);
        // GameObject cube = obj as GameObject;
        // cube.transform.position = Vector3.zero;
        // cube.transform.localScale = Vector3.one;
        // cube.transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
