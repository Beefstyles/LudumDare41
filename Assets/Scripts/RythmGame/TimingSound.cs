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
    private bool _noteToBeHit;
    RythmSounds _rythmSounds;
    GameController _gameController;
    StreakCounter _streakCounter;

    void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
        _rythmSounds = FindObjectOfType<RythmSounds>();
        _streakCounter = FindObjectOfType<StreakCounter>();
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

    void Update()
    {
        CheckForErrenousNoteHits();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "SoundBar")
        {
            _noteToBeHit = true;
        }
    }


    void OnTriggerStay(Collider coll)
    {
        if(coll.gameObject.tag == "SoundBar") 
        {
            switch (note)
            {
                case (NoteNumbers.Note1):
                    if (Input.GetButton("Note1") && _noteToBeHit)
                    {
                        SuccesfulNoteHit();
                    }
                    break;
                case (NoteNumbers.Note2):
                    if (Input.GetButton("Note2") && _noteToBeHit)
                    {
                        SuccesfulNoteHit();
                    }
                    break;
                case (NoteNumbers.Note3):
                    if (Input.GetButton("Note3") && _noteToBeHit)
                    {
                        SuccesfulNoteHit();
                    }
                    break;
                case (NoteNumbers.Note4):
                    if (Input.GetButton("Note4") && _noteToBeHit)
                    {
                        SuccesfulNoteHit();
                    }
                    break;
                case (NoteNumbers.Beat):
                    break;
            }
            if (!_noteToBeHit)
            {
                //Debug.Log("Tick");
                if (!sound.isPlaying)
                {
                    sound.Stop();
                    sound.Play();
                }
            }
         } 
    }

    void SuccesfulNoteHit()
    {
        _noteToBeHit = false;
        _rythmSounds.CorrectNoteHit.Play();
        NotifyTurrets();
        _streakCounter.StreakCounterVal++;
    }

    void CheckForErrenousNoteHits()
    {
        if (!_noteToBeHit && (Input.GetButtonDown("Note1") || Input.GetButtonDown("Note2") || Input.GetButtonDown("Note3") || Input.GetButtonDown("Note4")))
        {
            _rythmSounds.MissedNoteHit.Play();
        }
    }

    void NotifyTurrets()
    {
        foreach (var turret in _gameController.TurretControllers)
        {
            turret.SetIfCanFire(note);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "SoundBar")
        {
            if (_noteToBeHit && !note.Equals(NoteNumbers.Beat))
            {
                Debug.Log("Missed note");
                _rythmSounds.MissedNoteEntirely.Play();
                _noteToBeHit = false;
                _streakCounter.StreakCounterVal = 0;
                _streakCounter.DamageMultiplierVal = 1;
            }

            switch (note)
            {
                case (NoteNumbers.Note1):
                    _gameController.FireTurretsCanFire = false;
                    break;
                case (NoteNumbers.Note2):
                    _gameController.IceTurretsCanFire = false;
                    break;
                case (NoteNumbers.Note3):
                    _gameController.PoisonTurretsCanFire = false;
                    break;
                case (NoteNumbers.Note4):
                    _gameController.EarthTurretsCanFire = false;
                    break;
            }
            

            //Debug.Log("Tock");
            if (sound.isPlaying)
            {
                sound.Stop();
            }
        }
    }
}
