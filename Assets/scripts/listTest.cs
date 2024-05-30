using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        listTest<int> list_int;
        list_int = new listTest<int>();
        list_int.add(1);
        list_int.add(2);
        list_int.add(3);

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
