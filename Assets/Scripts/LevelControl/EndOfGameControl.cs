using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfGameControl : MonoBehaviour
{
    private RaycastHit _hit;

    public GameObject EndOfGameParts;
    public Camera MainCamera;
    public TextMeshPro RoundsSurvivedText;
    private GameController _gameController;

    void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }
    public void DisplayEndOfGame()
    {
        Time.timeScale = 0F;
        MainCamera.gameObject.SetActive(false);
        EndOfGameParts.SetActive(true);
        RoundsSurvivedText.text = string.Format("{0} ROUNDS", _gameController.CurrentRoundNumber);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit, 100.0F))
            {
                if(_hit.transform.name == "ExitGame")
                {
                    Application.Quit();
                    Debug.Log("Quit");
                }
                if (_hit.transform.name == "RestartGame")
                {
                    Application.Quit();
                    Debug.Log("Restart");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
            
