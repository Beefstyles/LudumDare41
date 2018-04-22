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
    SoundBarMovement _soundBarMovement;

    void Start()
    {
        EnemySpawnPoint = FindObjectOfType<StartBlock>().transform;
        Waypoints = FindObjectsOfType<WaypointNumber>();
        _gameController = FindObjectOfType<GameController>();
        _buildController = FindObjectOfType<BuildController>();
        _soundBarMovement = FindObjectOfType<SoundBarMovement>();
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
        BuildMode = true;
        _soundBarMovement.ResetSongBar();
    }

    IEnumerator DelayEnemySpawn()
    {
        for (int i = NumberOfEnemiesToSpawn; i >= 0; i--)
        {
            yield return new WaitForSeconds(TimeBetweenSpawn);
            Instantiate(Enemy, new Vector3(EnemySpawnPoint.position.x, 3F, EnemySpawnPoint.position.z), Quaternion.identity);
        }
    }
}
