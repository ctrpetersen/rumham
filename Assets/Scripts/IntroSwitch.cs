using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroSwitch : MonoBehaviour {

    private double time;
    private double currentTime;

    public VideoPlayer video;

    // Use this for initialization
    void Start () {
        time = video.clip.length-0.5;
    }
	
	// Update is called once per frame
	void Update () {
	    currentTime = video.time;
	    if (currentTime >= time)
	    {
	        SceneManager.LoadScene("Level_one");
	    }
    }

    
}
