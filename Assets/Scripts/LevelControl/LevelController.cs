using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public WaypointNumber[] Waypoints;
    public GameObject Enemy;
    GameController _gameController;
    BuildController _buildController;
    public bool BuildMode = true;
    public int NumberOfEnemiesToSpawn = 5;
    public float TimeBetweenSpawn = 1F;
    public Transform EnemySpawnPoint;

    void Start()
    {
        EnemySpawnPoint = FindObjectOfType<StartBlock>().transform;
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
        StartCoroutine("DelayEnemySpawn");
    }

    public void EndRound()
    {
        _buildController.BuildMenu.SetActive(true);
        _gameController.CurrentRoundNumber++;
    }

    IEnumerator DelayEnemySpawn()
    {
        for (int i = NumberOfEnemiesToSpawn; i >= 0; i--)
        {
            yield return new WaitForSeconds(TimeBetweenSpawn);
            Instantiate(Enemy, EnemySpawnPoint.position, Quaternion.identity);
        }
    }
}
