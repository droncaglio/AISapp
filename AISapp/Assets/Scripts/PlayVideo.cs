using System.Collections;
using System.Collections.Generic;
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

        for (int i = 1; i < debug.Length+1; i++)
        {
            v.errorReceived += VideoPlayer_errorReceived;

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
        v.Play();
        if (debug[0] != null)
        {
            if (v.isPlaying)
            {
                debug[0].text = "video is playing";
            }
            else if (!v.isPlaying)
            {
                debug[0].text = "video is not playing";
                v.Stop();
                
            }

            if (v.isPrepared)
            {
                debug[2].text = "video is prepared";
                v.Play();
            }
            else
            {
                debug[2].text = "video is not prepared";
                v.Prepare();
            }
            

            debug[1].text = v.frame.ToString();
        }
        

    }

    bool isPaused = false;

   
}
