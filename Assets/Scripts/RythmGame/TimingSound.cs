using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingSound : MonoBehaviour {

    public NoteNumbers note;
    AudioSource sound;
    public GameObject Note1, Note2, Note3, Note4, Beat;
    private GameObject _noteSoundLoc;


    void Awake()
    {
        Note1 = gameObject.transform.Find("Note1").gameObject;
        Note2 = gameObject.transform.Find("Note2").gameObject;
        Note3 = gameObject.transform.Find("Note3").gameObject;
        Note4 = gameObject.transform.Find("Note4").gameObject;
        Beat = gameObject.transform.Find("Beat").gameObject;

        switch (note)
        {
            case (NoteNumbers.Note1):
                _noteSoundLoc = Note1;
                break;
            case (NoteNumbers.Note2):
                _noteSoundLoc = Note2;
                break;
            case (NoteNumbers.Note3):
                _noteSoundLoc = Note3;
                break;
            case (NoteNumbers.Note4):
                _noteSoundLoc = Note4;
                break;
            case (NoteNumbers.Beat):
                _noteSoundLoc = Beat;
                break;
        }
        sound = _noteSoundLoc.GetComponent<AudioSource>();
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
