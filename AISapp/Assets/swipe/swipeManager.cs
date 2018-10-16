using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipeManager : MonoBehaviour {

    public Swipe swipeControl;
    public GameObject[] objectsToSwap;
    int objetoAtual = 0;
	
	// Update is called once per frame
	void Update () {
      
        if (swipeControl.SwipeLeft || swipeControl.SwipeUp)
        {
            for (int i = 0; i < objectsToSwap.Length; i++)
            {
                objectsToSwap[i].SetActive(false);
            }

            objetoAtual++;

            if (objetoAtual == objectsToSwap.Length)
            {
                objetoAtual = 0;
            }
            objectsToSwap[objetoAtual].SetActive(true);

        }

        if (swipeControl.SwipeRight || swipeControl.SwipeDown)
        {
            for (int i = 0; i < objectsToSwap.Length; i++)
            {
                objectsToSwap[i].SetActive(false);
            }
            objetoAtual--;

            if (objetoAtual < 0)
            {
                objetoAtual = objectsToSwap.Length - 1;
            }
            objectsToSwap[objetoAtual].SetActive(true);
        }
    }
}
