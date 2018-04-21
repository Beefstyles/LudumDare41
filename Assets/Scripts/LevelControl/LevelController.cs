using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public WaypointNumber[] waypoints;

	void Start ()
    {
        waypoints = FindObjectsOfType<WaypointNumber>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
