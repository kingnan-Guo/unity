using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class listTest : MonoBehaviour
{

    int my_comp(int a, int b){
        if (a>b) return 1;
        else if (a<b) return -1;
        else return 0;
    }


    class player{
        public int id;
        public void test_Foo(){
            Debug.Log("test_Foo ="+ id);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("List");
        List<int> myList = new List<int>();
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        Debug.Log("myList[0]"+myList[0]);



        int i = myList.IndexOf(2);
        Debug.Log("IndexOf = "+i);
        myList.Remove(2);

        foreach (int item in myList)
        {
            Debug.Log("item ="+item);
        }

        myList.Sort();

        myList.Sort(this.my_comp);
        foreach (int item in myList)    
        {
            Debug.Log("item ="+item);
        }
  



        // =======

        ArrayList myArrayList = new ArrayList();
        myArrayList.Add(1);
        myArrayList.Add("two");
        myArrayList.Add(3.14f);

        int ivalue = (int)myArrayList[0];
        string svalue = (string)myArrayList[1];
        float f = (float)myArrayList[2];
        Debug.Log("ivalue = "+ivalue);
        Debug.Log("svalue = "+svalue);
        Debug.Log("f = "+f);

        myArrayList.Insert(1, "three");
        myArrayList.Reverse();



        // 字典 表
        Dictionary<string, int> myDictionary = new Dictionary<string, int>();
        myDictionary.Add("one", 1);
        myDictionary.Add("two", 2);

        Debug.Log(myDictionary.Count);
        if(myDictionary.ContainsKey("two")){
            Debug.Log("ContainsKey"+ myDictionary["two"]);
        }

        if(myDictionary.ContainsValue(2)){
            Debug.Log("ContainsValue");
        }


        

        
        foreach (KeyValuePair<string, int> kvp in myDictionary)
        {
            Debug.Log("Key = "+kvp.Key);
            Debug.Log("Value = "+kvp.Value);
        }


        foreach (string key in myDictionary.Keys){
            
            Debug.Log("Key = "+key + "value = "+myDictionary[key]);
        }


        Dictionary<int, player> playerDictionary = new Dictionary<int, player>();
        player p1 = new player();
        p1.id = 1;
        player p2 = new player();
        p2.id = 2;

        playerDictionary.Add(1, p1);
        playerDictionary.Add(2, p2);

        playerDictionary[2].test_Foo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
