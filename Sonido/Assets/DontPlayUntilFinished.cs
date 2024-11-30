using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontPlayUntilFinished : MonoBehaviour
{
    private StudioEventEmitter emitter;
    void Start()
    {
        emitter = this.gameObject.GetComponent<StudioEventEmitter>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (emitter.IsPlaying())
        {
            emitter.EventPlayTrigger = EmitterGameEvent.None;
        }
        else
        {
			emitter.EventPlayTrigger = EmitterGameEvent.ObjectMouseDown;
		}
    }
}
