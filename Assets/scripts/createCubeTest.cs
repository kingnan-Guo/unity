using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;






public class createCubeTest : MonoBehaviour
{
    // [System.Serializable]// 用于存储生成的立方体的引用
    private GameObject cube;


    // [System.Serializable]
    // public class CubeData
    // {
    //     public string name;
    //     public Vector3 position;
    //     public Vector3 scale;
    //     public string color;

    //     public CubeData(string name, Vector3 position)
    //     {
    //         this.name = name;
    //         this.position = position;
    //         // this.scale = scale;
    //         // this.color = color;
    //     }
    // }

    // public CubeData cubeData;


    // Start is called before the first frame update
    void Start()
    {
        // 初始化 CubeData 对象
        CreateCube(new Vector3(0, 0, 0));
    }


    void CreateCube(Vector3 position)
    {
        // 创建一个立方体对象
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        // 设置立方体的位置
        cube.transform.position = position;

        // 设置立方体的名称（可选）
        cube.name = "GeneratedCube";

        // 设置立方体的颜色（可选）
        Renderer renderer = cube.GetComponent<Renderer>();
        renderer.material.color = Color.blue; // 你可以更改为任何颜色


        cube.AddComponent<CubeInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.GetComponent<CubeInfo>() != null)
            {
                // 获取立方体信息并打印到控制台
                CubeInfo cubeInfo = hitObject.GetComponent<CubeInfo>();
                // string jsonInfo = cubeInfo.GetCubeInfo();
                // Debug.Log("Hovered Cube JSON Info: " + jsonInfo);
                Debug.Log("Hovered Cube JSON Info: " + cubeInfo.GetCubeInfo());
            }
        }
    }
}
