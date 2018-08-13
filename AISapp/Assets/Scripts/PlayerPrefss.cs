using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPrefss : MonoBehaviour {

    public InputField email;
    public InputField senha;

    public GameObject loading;

    public void LembreMe<Scene>(Scene scene)
    {
        if (email.text != "" && senha.text != "")
        {
            PlayerPrefs.SetString("email", email.text);
            PlayerPrefs.SetString("senha", senha.text);
        }      
    }

    private void Start()
    {
        email.text = PlayerPrefs.GetString("email", "");
        senha.text = PlayerPrefs.GetString("senha", "");

        if (PlayerPrefs.GetInt("lembrar") == 1)
        {
            
            StartCoroutine(LoadYourAsyncScene());          
        }
    }

    private void Awake()
    {
        SceneManager.sceneUnloaded += LembreMe;
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("ARbundle");

        loading.SetActive(true);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress/0.9f);
            Debug.Log(progress);
            yield return null;
        }
    }
}
