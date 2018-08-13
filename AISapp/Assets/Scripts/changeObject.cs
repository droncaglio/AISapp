using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeObject : MonoBehaviour {

    public GameObject[] objectRA;
    public Slider s;
    public int counter;

    // Use this for initialization
    void Start ()
    {

        counter = 1;

		for(int i = 0; i < objectRA.Length; i++)
        {
            objectRA[i].SetActive(false);
        }

        objectRA[1].SetActive(true);
	}


    public void changeAR()
    {

        if (s.value==0)
        {
            counter--;
        }

        if (s.value ==2)
        {
            counter++;
        }

        if (counter ==3)
        {
            counter = 0;
        }
        else if (counter == -1)
        {
            counter = 2;
        }

        
        for (int i = 0; i < objectRA.Length; i++)
        {
            objectRA[i].SetActive(false);
        }


        objectRA[counter].SetActive(true);
        s.value = 1;
    }

	
	// Update is called once per frame
	void Update () {


		
	}
}
