using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int _numberOfEnemiesLeft;
    private int _currentRoundNumber;

    private int _numberOfLivesLeft;
    private float _moneyLeft = 100000;
    public bool GameOn;
    GameText _gameText;
    private int _currentSelectedBuildingCost;

    public bool FireTurretsCanFire, IceTurretsCanFire, PoisonTurretsCanFire, EarthTurretsCanFire;
    public int NumberOfFireTurrets = 0, NumberOfIceTurrets = 0, NumberOfPoisonTurrets = 0, NumberOfEarthTurrets = 0;
    public TurretController[] TurretControllers;

    private void Start()
    {
        _gameText = GetComponent<GameText>();
    }
    public int NumberOfLivesLeft
    {
        get
        {
            return _numberOfLivesLeft;
        }

        set
        {
            _numberOfLivesLeft = value;
            _gameText.LivesTextUpdate();
            if (_numberOfLivesLeft <= 0)
            {
                StartCoroutine("LevelFailed");
            }
        }
    }

    public int NumberOfEnemiesLeft
    {
        get
        {
            return _numberOfEnemiesLeft;
        }

        set
        {
            _numberOfEnemiesLeft = value;
            _gameText.EnemiesLeftTextUpdate();
        }
    }

    public int CurrentRoundNumber
    {
        get
        {
            return _currentRoundNumber;
        }

        set
        {
            _currentRoundNumber = value;
            _gameText.RoundTextUpdate();
        }
    }

    public float MoneyLeft
    {
        get
        {
            return _moneyLeft;
        }

        set
        {
            _moneyLeft = value;
            _gameText.MoneyTextUpdate();
        }
    }

    public int CurrentSelectedBuildingCost
    {
        get
        {
            return _currentSelectedBuildingCost;
        }

        set
        {
            _currentSelectedBuildingCost = value;
            _gameText.CurrentBuildingCostTextUpdate(_currentSelectedBuildingCost);
        }
    }

    public void DecreaseLivesByOne()
    {
        NumberOfLivesLeft--;
    }

    IEnumerator LevelFailed()
    {
        GameOn = false;
        yield return new WaitForSeconds(0.5F);
    }

    public void UpdateListOfTurrets()
    {
        TurretControllers = FindObjectsOfType<TurretController>();
    }
}
