using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingSound : MonoBehaviour {

    public NoteNumbers note;
    AudioSource sound;
    public GameObject Note1, Note2, Note3, Note4, Beat;
    private GameObject _noteSoundLoc;
    public Material Note1Mat, Note2Mat, Note3Mat, Note4Mat;
    private Material _noteMaterial;

    void Awake()
    {
        Note1 = gameObject.transform.Find("Note1").gameObject;
        Note2 = gameObject.transform.Find("Note2").gameObject;
        Note3 = gameObject.transform.Find("Note3").gameObject;
        Note4 = gameObject.transform.Find("Note4").gameObject;
        Beat = gameObject.transform.Find("Beat").gameObject;

        Note1Mat = (Material)Resources.Load("Note1Mat", typeof(Material));
        Note2Mat = (Material)Resources.Load("Note2Mat", typeof(Material));
        Note3Mat = (Material)Resources.Load("Note3Mat", typeof(Material));
        Note4Mat = (Material)Resources.Load("Note4Mat", typeof(Material));

        switch (note)
        {
            case (NoteNumbers.Note1):
                _noteSoundLoc = Note1;
                _noteMaterial = Note1Mat;
                break;
            case (NoteNumbers.Note2):
                _noteSoundLoc = Note2;
                _noteMaterial = Note2Mat;
                break;
            case (NoteNumbers.Note3):
                _noteSoundLoc = Note3;
                _noteMaterial = Note3Mat;
                break;
            case (NoteNumbers.Note4):
                _noteSoundLoc = Note4;
                _noteMaterial = Note4Mat;
                break;
            case (NoteNumbers.Beat):
                _noteSoundLoc = Beat;
                _noteMaterial = Note1Mat;
                break;
        }
        sound = _noteSoundLoc.GetComponent<AudioSource>();
        gameObject.GetComponent<MeshRenderer>().material = _noteMaterial;
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "SoundBar") 
        {
            //Debug.Log("Tick");
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
            //Debug.Log("Tock");
            if (sound.isPlaying)
            {
                sound.Stop();
            }
        }
    }
}
