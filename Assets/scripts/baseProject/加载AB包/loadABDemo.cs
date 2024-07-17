using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadABDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string name = "Assets/resources/dahuyuahqu.prefab";
        // name = "Assets/dahuyuahqu 1.fbx";

        GameObject obj = ABManager.GetInstance().LoadRes("dahuamap", name) as GameObject;
        obj.transform.position = new Vector3(0, 0, 0);

        // GameObject obj = ABManager.GetInstance().LoadRes("dahuamappref", name) as GameObject;
        
        // obj.tag = "building";
        // obj.transform.Find("");
        Debug.Log("obj.transform.childCount =="+ obj.transform.childCount);
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if(obj.transform.GetChild(i).name.Contains("floor")){
                obj.transform.GetChild(i).tag ="building";
            }
        }
        // GameObject.Find("Camera").SetActive(false); 



        string tree = "Assets/resources/tree.prefab";
        // name = "Assets/dahuyuahqu 1.fbx";

        GameObject treeObj = ABManager.GetInstance().LoadRes("treemap", tree) as GameObject;
        treeObj.transform.position = new Vector3(-7.26f, -4.2f, -4.22f);
        // 加载预制体


        // obj.transform.position = -Vector3.up;

        // object obj1 = ABManager.GetInstance().LoadRes("dahuamap", "Assets/dahuyuahqu 1.fbx", typeof(GameObject));
        
        // object obj2 = ABManager.GetInstance().LoadRes<GameObject>("dahuamap", "Assets/dahuyuahqu 1.fbx");

        // ABManager.GetInstance().LoadResAsync<GameObject>("dahuamap", "Assets/dahuyuahqu 1.fbx", (obj) =>
        // {
        //     obj.transform.position = -Vector3.up;
        // });

        // ABManager.GetInstance().LoadResAsync<Object>("dahuamate", "Assets/textures/men.jpg", (obj) =>
        // {
        //     // obj.transform.position = -Vector3.up;
        //     Debug.Log("加载完成"+ obj);
        // });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
