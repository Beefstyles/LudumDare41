using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int _numberOfEnemiesLeft;
    private int _currentRoundNumber;

    private int _numberOfLivesLeft;
    private float _moneyLeft;
    public bool GameOn;
    GameText _gameText;

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

    public void DecreaseLivesByOne()
    {
        NumberOfLivesLeft--;
    }

    IEnumerator LevelFailed()
    {
        GameOn = false;
        yield return new WaitForSeconds(0.5F);
    }
}
