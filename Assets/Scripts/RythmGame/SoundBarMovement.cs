using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBarMovement : MonoBehaviour {

    [Range(0.0F, 10.0F)]
    public float SpeedOfMovement;

	void Update ()
    {
        transform.Translate(new Vector3(1F, 0F, 0F) * SpeedOfMovement);
	}
}
