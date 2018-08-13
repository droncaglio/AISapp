using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLoadBundle : MonoBehaviour {

    public string url;

   public void BaixaAsset () {

        StartCoroutine(DownloadAsset());
	}
	
	IEnumerator DownloadAsset()
    {
        WWW www = new WWW(url);
        yield return www;
        AssetBundle assetBundle = www.assetBundle;
        GameObject g = Instantiate(assetBundle.LoadAsset("Cubo") as GameObject);
    }
}
