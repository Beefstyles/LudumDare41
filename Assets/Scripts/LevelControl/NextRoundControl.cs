using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundControl : MonoBehaviour {

    LevelController _levelController;

    void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
    }
	public void CheckToStartNextRound()
    {
        if (_levelController.BuildMode)
        {
            _levelController.StartNextRound();
        }
    }
}
