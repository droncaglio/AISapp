using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using NatShareU;

public class AppManager : MonoBehaviour {

    [Header("Targets e URLs")]
    public DefaultTrackableEventHandler[] imageTarget;
    //public string[] urlVideo;
    public string[] urlAsset;
    public string[] urlSites;
    public string[] assetName;

    [Header("Objetos Interface")]
    public GameObject panelLoading;
    public GameObject panelInternet;
    public GameObject panelButtons;
    public Button buttonAction;
    public Button buttonShare;
    public Text textoButtonAction;
    public RawImage screenShot;

    [Header("Configs")]
    [Range(1, 10)]
    public int poolLimit;

    bool[] jaBaixou;
    bool temInternet = false;
    GameObject[] poolBaixados;
    AssetBundle[] asset;
    int poolCounter = 0;
    int indexAtual = 0;
    
    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void UnloadAssets()
    {
        AssetBundle.UnloadAllAssetBundles(true);
    }

    public void ActionSite()
    {
        Application.OpenURL(urlSites[indexAtual]);
    }
    
    public void SaveScreenShot()
    {
        panelButtons.SetActive(false);
        StartCoroutine(ScreenShot(0.2f));     
    }

    IEnumerator ScreenShot(float sec)
    {
        yield return new WaitForSeconds(sec);

        //Create a new texture with the width and height of the screen
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        //Read the pixels in the Rect starting at 0,0 and ending at the screen's width and height
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();

        screenShot.texture = texture;
        screenShot.gameObject.SetActive(true);

        //Reset the grab state
        NatShare.Share(texture);

        StartCoroutine(Waitfor(0.3f));

    }

    IEnumerator Waitfor(float sec)
    {
        yield return new WaitForSeconds(sec);
        screenShot.gameObject.SetActive(false);
        panelButtons.SetActive(true);

    }

    // Use this for initialization
    void Start () {

        poolBaixados = new GameObject[poolLimit];
        jaBaixou = new bool[imageTarget.Length];

        for (int i = 0; i < jaBaixou.Length; i++)
        {
            jaBaixou[i] = false;
        }

        StartCoroutine(checkInternetConnection((isConnected) => {
            if (!isConnected)
            {
                panelInternet.SetActive(true);
            }
            else
            {
                temInternet = true;
            }
        }));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TrackableFound(int index)
    {
        buttonAction.gameObject.SetActive(true);
        buttonShare.gameObject.SetActive(true);
        screenShot.gameObject.SetActive(false);
        buttonAction.interactable = true;
        buttonShare.interactable = true;
        indexAtual = index;

        if (jaBaixou[index])
        {
            imageTarget[index].transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            if (temInternet)
            {
                StartCoroutine(DownloadAsset(index));
            }
            else
            {
                StartCoroutine(checkInternetConnection((isConnected) => {
                    if (isConnected)
                    {
                        panelInternet.SetActive(false);
                        StartCoroutine(DownloadAsset(index));
                    }
                    else
                    {
                        panelInternet.SetActive(true);
                    }
                }));
            }
        }
      
    }

    public void TrackableLost(int index)
    {
        imageTarget[index].transform.GetChild(0).gameObject.SetActive(false);
        buttonAction.interactable = false;
        buttonShare.interactable = false;
    }

    // This check the InternetConnection trying to connect to google.com
    IEnumerator checkInternetConnection(Action<bool> action)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            temInternet = false;
            action(false);
        }
        else
        {
            temInternet = true;
            action(true);
        }
    }

    IEnumerator DownloadAsset(int index)
    {
        panelLoading.SetActive(true);
        WWW www = new WWW(urlAsset[index]);
        yield return www;
        Debug.Log("antes");
        AssetBundle assetBundle = www.assetBundle;
        Debug.Log("depois");
        GameObject g = Instantiate(assetBundle.LoadAsset(assetName[index]) as GameObject);
        g.transform.parent = imageTarget[index].transform;
        jaBaixou[index] = true;
        Pool(g);
        panelLoading.SetActive(false);

    }

    bool limitPass = false;

    void Pool(GameObject g)
    {
        if (poolCounter == poolLimit)
        {
            poolCounter = 0;
            limitPass = true;
            
        }

        if (limitPass)
        {
            Destroy(poolBaixados[poolCounter]);
        }

        poolBaixados[poolCounter] = g;

        poolCounter++;
      
    }
}
