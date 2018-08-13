using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {

    public DefaultTrackableEventHandler trackable;

    public VideoPlayer video;
    bool playou = false;
   
	// Use this for initialization
	void Start ()
    {

        video.Prepare();

	}
	
	// Update is called once per frame
	void Update () {
       /*
        if (!playou && trackable.statusTrack)
        {
            video.Play();
            playou = true;
        }

        if (!trackable.statusTrack)
        {
            video.Stop();
            playou = false;
        }*/
	}
}
