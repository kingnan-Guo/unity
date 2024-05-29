using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CubeInfo : MonoBehaviour
{
    [System.Serializable]
    public class CubeData
    {
        public string name;
        public Vector3 position;
        public Vector3 scale;
        public string color;
        public string info;

        public CubeData(string name, Vector3 position, Vector3 scale, string color, string info)
        {
            this.name = name;
            this.position = position;
            this.scale = scale;
            this.color = color;
            this.info = info;
        }
    }

    public CubeData cubeData;

    void Start()
    {
        // 初始化 CubeData 对象
        cubeData = new CubeData(
            "Test Cube",
            transform.position,
            transform.localScale,
            ColorUtility.ToHtmlStringRGBA(GetComponent<Renderer>().material.color),
            "{id:1, code: '001'}"
        );

        // 将 CubeData 对象序列化为 JSON 字符串
        // string jsonInfo = JsonConvert.SerializeObject(cubeData, Formatting.Indented);
        // Debug.Log("Cube JSON Info: " + jsonInfo);
    }
    public string GetCubeInfo()
    {
        // return JsonConvert.SerializeObject(cubeData, Formatting.Indented);
        return cubeData.info;
    }

}
