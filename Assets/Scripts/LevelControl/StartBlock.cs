using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour {

    private LevelController _levelController;
    private Transform _lookRot;

	void Start ()
    {
        _levelController = FindObjectOfType<LevelController>();
        StartCoroutine("DelayLookAt");
	}

    IEnumerator DelayLookAt()
    {
        yield return new WaitForSeconds(0.5F);
        foreach (var waypoint in _levelController.waypoints)
        {
            if (waypoint.WayPointNumber == 1)
            {
                _lookRot = waypoint.gameObject.transform;
            }
        }
        gameObject.transform.LookAt(_lookRot.transform.position);
    }


	
}
