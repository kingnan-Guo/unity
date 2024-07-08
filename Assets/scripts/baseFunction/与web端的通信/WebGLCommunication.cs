using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class WebGLCommunication : MonoBehaviour {
    [DllImport("__Internal")]
    private static extern void Hello();
    [DllImport("__Internal")]
    private static extern void HelloString(string str);
    void Start() {
        Hello();
        HelloString("This is a string.");
    }
}
