using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class addResources : MonoBehaviour
{
    ResourceRequest resourceRequest;
    // Start is called before the first frame update
    void Start()
    {
        // 添加资源
        // 创建 cube 
        //   GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        PrimitiveType primitiveType = PrimitiveType.Cube;
        GameObject cube = createNode(primitiveType, new Vector3(10, 0, 0), Color.red, "cube", new Vector3(0, 0, 0), transform);


        cube.AddComponent<AudioSource>();
        // 设置 cube 的质量
        AudioClip clip = Resources.Load<AudioClip>("Audio/80s");
        AudioSource audio = cube.GetComponent<AudioSource>();
        audio.clip = clip;
        if(!audio.isPlaying){
            audio.Play();
        }


        // 加载 txt
        TextAsset textAsset = Resources.Load<TextAsset>("txt/test");
        Debug.Log(textAsset.name);
        Debug.Log(textAsset.text);


        // 加载 json
        TextAsset jsonAsset = Resources.Load<TextAsset>("json/test");
        Debug.Log(jsonAsset.name);
        Debug.Log(jsonAsset.text);

        createNewNewCanvas(this.transform.parent);


        StartCoroutine(createPrefab(this.transform.parent));

    }


    // 创建画布 
    void createNewNewCanvas(Transform transform){
        // 创建画布 
        GameObject canvas = new GameObject("Canvas");
        canvas.transform.SetParent(transform);
        canvas.transform.localPosition = new Vector3(0, 0, 0);


        
        // 设置canvas的宽度和高度

        canvas.AddComponent<RectTransform>();
        RectTransform rectTransform = canvas.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(1920, 1080);

        canvas.AddComponent<Canvas>();
        canvas.AddComponent<GraphicRaycaster>();

        // 创建 Image
        GameObject img = new GameObject("Image");
        img.transform.SetParent(canvas.transform);
        img.transform.localPosition = new Vector3(0, 0, 0); 
        img.AddComponent<Image>();

        // 设置 Image 的 sprite
        Sprite sprite = Resources.Load<Sprite>("Textures/blue");
        img.GetComponent<Image>().sprite = sprite;

    }

    IEnumerator createPrefab(Transform transform){

        this.resourceRequest = Resources.LoadAsync<GameObject>("prefabPage/Capsule");

        yield return  this.resourceRequest;

        if(this.resourceRequest.isDone){
            GameObject obj = this.resourceRequest.asset as GameObject;
            GameObject prefab = Instantiate(obj, new Vector3(0, 0, -20), Quaternion.identity);
            prefab.transform.SetParent(transform);
            prefab.transform.localPosition = new Vector3(0, 0, 30);
            prefab.name = "Capsule_1";

            // GameObject.Instantiate(obj, new Vector3(0, 0, -20), Quaternion.identity);
        }


        // Capsule.AddComponent<Renderer>();
        // Capsule.GetComponent<Renderer>().material.color = Color.blue;
        // GameObject.Instantiate(Capsule, new Vector3(0, 0, -20), Quaternion.identity);
        // 创建 Prefab
        // GameObject prefab = new GameObject("Prefab");
        // prefab.transform.SetParent(transform);
        // prefab.transform.localPosition = new Vector3(0, 0, 0);

        
    }
        // 创建画布

    GameObject createNode(PrimitiveType primitiveType, Vector3 vector3, Color color, string name, Vector3 Rotate, Transform transform){
        
        
        // PrimitiveType primitiveType = PrimitiveType.Cube;
        GameObject cube = GameObject.CreatePrimitive(primitiveType);

        // 设置 cube 的位置
        cube.transform.position = vector3;

        // 设置 cube 的颜色
        cube.GetComponent<Renderer>().material.color = color;

        // 设置 cube 的名称
        cube.name = name;
        // cube.AddComponent<BoxCollider>();
        // cube.AddComponent<Rigidbody>();
        // 设置 cube 的旋转
        cube.transform.Rotate(Rotate);
        // 添加 cube 到场景中
        cube.transform.parent = transform;

        return cube;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
