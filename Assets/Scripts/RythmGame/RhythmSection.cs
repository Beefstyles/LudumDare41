using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSection : MonoBehaviour {

    public int RhythmSectionNumber;

    public GameObject FireNote, IceNote, PoisionNote, EarthNote;
    private TimingSound[] _timingSounds;

    void Start()
    {
        _timingSounds = gameObject.GetComponentsInChildren<TimingSound>();

        foreach (var timingSound in _timingSounds)
        {
            switch (timingSound.note)
            {
                case (NoteNumbers.Note1):
                    FireNote = timingSound.gameObject;
                    break;
                case (NoteNumbers.Note2):
                    IceNote = timingSound.gameObject;
                    break;
                case (NoteNumbers.Note3):
                    PoisionNote = timingSound.gameObject;
                    break;
                case (NoteNumbers.Note4):
                    EarthNote = timingSound.gameObject;
                    break;
            }
        }
    }


}
