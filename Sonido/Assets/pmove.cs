using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pmove : MonoBehaviour
{
    private StudioEventEmitter emitter;
    Rigidbody rigidbody;
    bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing && rigidbody.velocity != Vector3.zero)
        {
            playing = true;
            emitter.Play();
        }
        else if (playing && rigidbody.velocity == Vector3.zero)
        {

            playing = false;
            emitter.Stop();
        }

    }
}


