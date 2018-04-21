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

    public Transform StartPoint;

	void Update ()
    {
        transform.Translate(new Vector3(1F, 0F, 0F) * SpeedOfMovement);
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "ResetPoint")
        {
            transform.position = StartPoint.position;
        }
    }
}
