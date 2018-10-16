using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {


    VideoPlayer v;

    Text[] debug = new Text[4];

	// Use this for initialization
	void Start ()
    {
        
        v = this.GetComponent<VideoPlayer>();

        v.errorReceived += VideoPlayer_errorReceived;
        v.Prepare();

        for (int i = 1; i < debug.Length+1; i++)
        {           
            Debug.Log("Canvas/PanelDebug/Panel/TextDebug" + i );
            debug[i-1] = GameObject.Find("Canvas/PanelDebug/Panel/TextDebug"+i).GetComponent<Text>();
        }
	}

    private void VideoPlayer_errorReceived(VideoPlayer source, string message)
    {
        debug[3].text = message;
        v.errorReceived -= VideoPlayer_errorReceived;//Unregister to avoid memory leaks
    }






    void Update()
    {
       

        if (debug[0] != null)
        {
            if (v.isPlaying)
            {
                debug[0].text = "video is playing";
            }
            else if (!v.isPlaying && v.isPrepared)
            {
                debug[0].text = "video is not playing";
                v.Play();
                
            }

            if (v.isPrepared)
            {
                debug[2].text = "video is prepared";
                v.Play();
            }
            else
            {
                debug[2].text = "video is not prepared tryimg to prepare";
                v.Prepare();
               

            }
            

            debug[1].text = v.frame.ToString();
        }

     

    }




    public delegate void ErrorEventHandler(VideoPlayer source, string message);

    bool isPaused = false;

   
}
