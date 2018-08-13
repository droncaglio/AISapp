using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayerPrefsInstruc : MonoBehaviour {

    public Toggle lembrar;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("lembrarInstruc") == 1)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LembreMeInstruc()
    {
        if (lembrar.isOn)
        {
            PlayerPrefs.SetInt("lembrarInstruc", 1);
        }
        else
        {
            PlayerPrefs.SetInt("lembrarInstruc", 0);
        }
    }
}
