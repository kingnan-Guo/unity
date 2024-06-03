using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class build_asset : Editor
{
    [MenuItem("kingnan/build_asset")]
    // Start is called before the first frame update
    public static void run(){
        Debug.Log("run");
        // 把所有的 
        // BuildPipeline.BuildAssetBundles("Assets/AssetsBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);
        BuildPipeline.BuildAssetBundles("Assets/AssetsBundles", BuildAssetBundleOptions.None, BuildTarget.WebGL);
    }
}
