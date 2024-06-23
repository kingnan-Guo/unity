using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonDataManager : baseManager<jsonDataManager>
{
    public Dictionary<string, object> dataDic = new Dictionary<string, object>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public T LoadData<T>(string jsonString, JsonType type = JsonType.JsonUtility) where T : new()
    // {
    //     if(jsonString.Equals("")){
    //         return new T();
    //     }
    //     T data = default(T);
    //     switch (type)
    //     {
    //         case JsonType.JsonUtility:
    //             data = JsonUtility.FromJson<T>(jsonString);
    //             break;
    //         default:
    //             break;
    //     }
    //     // return default(T);
    //     return data;
    // }


}
