using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update


    PLAYBACK_STATE playBackState;
    EventInstance eventInstance;
	void Start()
    {
        //this.eventInstance = RuntimeManager.CreateInstance(fountain);
		//eventInstance.start();
	}

    // Update is called once per frame
    void Update()
    {
        //eventInstance.getPlaybackState(out playBackState);
        //if (playBackState.Equals(PLAYBACK_STATE.STOPPED))
        //{
        //    eventInstance.start();
        //}
    }
}
