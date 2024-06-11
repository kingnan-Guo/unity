using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initProject : MonoBehaviour
{
    // Start is called before the first frame update

    struct cubeStruct{
        public Vector3 position;
        public Color color;
        public string name;
        public string parent;
    }

    


    void Start()
    {
        print("initProject");

        ArrayList cubeList = new ArrayList();

        for (int i = 0; i < 3; i++)
        {
            // 0~10 的随机数
            float rand = Random.Range(0.0f, 1.0f);
            // 0~10 的随机数
            float rand2 = Random.Range(0.0f, 5.0f);
            // 0~10 的随机数
            float rand3 = Random.Range(0.0f, 1.0f);
            cubeStruct cubeInfo = new cubeStruct();

            // Vector3 position = new Vector3(rand, rand2, rand3);
            // Debug.Log("cubeInfo.position ==" + position);
            cubeInfo.position = new Vector3(rand, rand2, rand3);
            cubeInfo.color = Color.red;
            cubeInfo.name = "device_imei_"+i;
            cubeInfo.parent = "first";
            cubeList.Add(cubeInfo);
        }

        Debug.Log("cubeList.Count ==" + cubeList.Count);
        for (int i = 0; i < cubeList.Count; i++)
        {
            cubeStruct cubeInfo = (cubeStruct)cubeList[i];
            GameObject cube = createCube();

            
       
            cube.transform.position = cubeInfo.position;
            cube.GetComponent<MeshRenderer>().material.color = cubeInfo.color;
            cube.name = cubeInfo.name;
            cube.transform.parent = GameObject.Find(cubeInfo.parent).transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    GameObject createCube(){

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // cube.transform.position = new Vector3(0, 0, 0);
        cube.transform.localScale = new Vector3(1, 1, 1);
        // cube.name = "cube";
        cube.AddComponent<BoxCollider>();
        cube.GetComponent<MeshRenderer>().material.color = Color.red;

        return cube;
    }
}
