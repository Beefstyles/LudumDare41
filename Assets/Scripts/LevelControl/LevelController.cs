using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public WaypointNumber[] Waypoints;
    public GameObject Enemy;
    GameController _gameController;
    BuildController _buildController;
    public bool BuildMode = true;

    void Start()
    {
        Waypoints = FindObjectsOfType<WaypointNumber>();
        _gameController = FindObjectOfType<GameController>();
        _buildController = FindObjectOfType<BuildController>();
    }

    void Update()
    {

    }

    public void StartNextRound()
    {
        BuildMode = false;
        _buildController.BuildMenu.SetActive(false);
    }

    public void EndRound()
    {
        _buildController.BuildMenu.SetActive(true);
        _gameController.CurrentRoundNumber++;
    }
}
