using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.getInstance().AddEventListener("MonsterDead", testFunction);
    }

    public void testFunction(object info){
        Debug.Log("testFunction Monster name = "+  (info as Monster).Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        EventCenter.getInstance().RemoveEventListener("MonsterDead", testFunction);
    }
}
