using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingSound : MonoBehaviour {

    AudioSource sound;

    void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "SoundBar") 
        {
            Debug.Log("Tick");
            if (!sound.isPlaying)
            {
                sound.Stop();
                sound.Play();
            }
         } 
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "SoundBar")
        {
            Debug.Log("Tock");
            if (sound.isPlaying)
            {
                sound.Stop();
            }
        }
    }
}
