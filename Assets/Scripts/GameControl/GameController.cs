using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int NumberOfEnemiesLeft;
    public int CurrentRoundNumber;

    private int _numberOfLivesLeft;
    public bool GameOn;

    public int NumberOfLivesLeft
    {
        get
        {
            return _numberOfLivesLeft;
        }

        set
        {
            _numberOfLivesLeft = value;
            if (_numberOfLivesLeft <= 0)
            {
                StartCoroutine("LevelFailed");
            }
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
