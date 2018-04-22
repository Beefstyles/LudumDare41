using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyControl : MonoBehaviour {

    [SerializeField]
    private int _currentWayPointTarget = 0;
    private LevelController _levelController;
    private bool _haveTarget = false;
    private Transform _currentTarget;
    public float Speed;
    private float _step;

    void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        SetNewWaypoint();
        Speed *= _levelController.SpeedOfEnemiesMultiplication;
    }
	
	void Update ()
    {
        if (_haveTarget)
        {
            _step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _step);
            transform.position = new Vector3(transform.position.x, 2F, transform.position.z);
            transform.LookAt(_currentTarget.position);
        }
	}

    IEnumerator DelayMovement()
    {
        yield return new WaitForSeconds(0.1F);
        foreach (var waypoint in _levelController.Waypoints)
        {
            if (waypoint.WayPointNumber == _currentWayPointTarget)
            {
                _currentTarget = waypoint.gameObject.transform;
                _haveTarget = true;
            }
        }
    }

    public void SetNewWaypoint()
    {
        _currentWayPointTarget++;
        StartCoroutine("DelayMovement");
    }

    
}
