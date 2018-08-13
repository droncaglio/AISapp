#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetBundleCreator : MonoBehaviour {

    //Creates a new menu (Build Asset Bundles) and item (Normal) in the Editor
    [MenuItem("Assets/Build Asset Bundle Normal")]
    static void BuildABsNone()
    {
        //Create a folder to put the Asset Bundle in.
        // This puts the bundles in your custom folder (this case it's "MyAssetBuilds") within the Assets folder.
        //Build AssetBundles with no special options
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }

    //Creates a new item (Uncompressed) in the new Build Asset Bundles menu
    [MenuItem("Assets/Build Asset Bundle Uncompressed")]
    static void BuildABsUncompressed()
    {
        //Build the AssetBundles in uncompressed build mode
        BuildPipeline.BuildAssetBundles("Assets/AssetBundlesUncompressed", BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android);
    }

}
#endif