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
    public float TimeBetweenSpawn = 3F;
    public Transform EnemySpawnPoint;
    SoundBarMovement _soundBarMovement;

    public float EnemiesToSpawnMultiplication = 1F;
    public float MoneyFromEnemiesMultiplication = 1F;
    public float TimeBetweenSpawnDivision = 1F;
    public float HealthOfEnemiesMultiplication = 1.05F;
    public float SpeedOfEnemiesMultiplication = 1F;
    public bool AllEnemiesSpawned = false;

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
        //_gameController.NumberOfEnemiesLeft = NumberOfEnemiesToSpawn;
        NumberOfEnemiesToSpawn = Mathf.FloorToInt(NumberOfEnemiesToSpawn + EnemiesToSpawnMultiplication);
        StartCoroutine("DelayEnemySpawn");
        AllEnemiesSpawned = false;
    }

    public void EndRound()
    {
        _buildController.BuildMenu.SetActive(true);
        _gameController.CurrentRoundNumber++;
        BuildMode = true;
        _soundBarMovement.ResetSongBar();
        UpdateValues();
        AllEnemiesSpawned = false;
    }

    IEnumerator DelayEnemySpawn()
    {

        for (int i = Mathf.FloorToInt(NumberOfEnemiesToSpawn); i > 0; i--)
        {
            yield return new WaitForSeconds(TimeBetweenSpawn);
            Instantiate(Enemy, new Vector3(EnemySpawnPoint.position.x, 3F, EnemySpawnPoint.position.z), Quaternion.identity);
            _gameController.NumberOfEnemiesLeft++;
        }
        AllEnemiesSpawned = true;
    }

    void UpdateValues()
    {
        EnemiesToSpawnMultiplication += 0.5F;
        MoneyFromEnemiesMultiplication += 0.1F;
        TimeBetweenSpawnDivision -= 0.01F;
        SpeedOfEnemiesMultiplication += 0.2F;
    }
}
