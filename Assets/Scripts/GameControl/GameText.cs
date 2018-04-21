using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameText : MonoBehaviour {

    public TextMeshPro MoneyText, RoundText, LivesText, EnemiesLeftText;

    GameController _gameController;

    void Start()
    {
        _gameController = GetComponent<GameController>();
        MoneyTextUpdate();
        RoundTextUpdate();
        LivesTextUpdate();
        EnemiesLeftTextUpdate();
    }

    public void MoneyTextUpdate()
    {
        MoneyText.text = string.Format("Money: {0}", _gameController.MoneyLeft);
    }

    public void RoundTextUpdate()
    {
        RoundText.text = string.Format("Round: {0}", _gameController.CurrentRoundNumber);
    }

    public void LivesTextUpdate()
    {
        LivesText.text = string.Format("Lives: {0}", _gameController.NumberOfLivesLeft);
    }

    public void EnemiesLeftTextUpdate()
    {
        LivesText.text = string.Format("Left: {0}", _gameController.NumberOfEnemiesLeft);
    }
}
