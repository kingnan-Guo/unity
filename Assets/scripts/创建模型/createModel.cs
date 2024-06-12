using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createModel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("json/test");

        Debug.Log(textAsset.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
