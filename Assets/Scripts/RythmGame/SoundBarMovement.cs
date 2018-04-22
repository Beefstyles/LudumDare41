using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NoteNumbers
{
    Note1, Note2, Note3, Note4, Beat
};

public class SoundBarMovement : MonoBehaviour {

    [Range(0.0F, 10.0F)]
    public float SpeedOfMovement;

    LevelController _levelController;

    public Transform StartPoint;

    void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
        ResetSongBar();
    }
	void Update ()
    {
        if (!_levelController.BuildMode)
        {
            transform.Translate(new Vector3(1F, 0F, 0F) * SpeedOfMovement);
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "ResetPoint")
        {
            ResetSongBar();
        }
    }

    public void ResetSongBar()
    {
        transform.position = StartPoint.position;
    }
}
