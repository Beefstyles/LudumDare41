using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSection : MonoBehaviour {

    public int RhythmSectionNumber;

    public GameObject FireNote, Note2, Note3, Note4;
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
                    Note2 = timingSound.gameObject;
                    break;
                case (NoteNumbers.Note3):
                    Note3 = timingSound.gameObject;
                    break;
                case (NoteNumbers.Note4):
                    Note4 = timingSound.gameObject;
                    break;
            }
        }
    }


}
