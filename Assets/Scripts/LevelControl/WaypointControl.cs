using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointControl : MonoBehaviour {

    private EnemyControl _enemyControl;

	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            _enemyControl = coll.GetComponent<EnemyControl>();
            _enemyControl.SetNewWaypoint();
        }
    }
}
