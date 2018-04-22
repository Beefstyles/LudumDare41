using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour {

    private RaycastHit _hit;
    public Transform CurrentTurretSpawnPoint;
    private bool _buildMenuUp = false;
    public GameObject BuildMenu;
    public GameObject FireTurret, IceTurret, PoisonTurret, EarthTurret;
    private ProjectileTypes _selectedTurretType;
    private GameController _gameController;
    private RythmValues _rhythmValues;
    private BuildingInfo _buildingInfo;
    public GameObject SelectedTurretSpawnLocation;
    public GameObject BuildBuildingButton;

    void Start()
    {
        _gameController = GetComponent<GameController>();
        _buildingInfo = GetComponent<BuildingInfo>();
        _rhythmValues = FindObjectOfType<RythmValues>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit, 100.0F))
            {
                if (_hit.transform.tag == "NextRoundButton")
                {
                    _hit.transform.gameObject.GetComponent<NextRoundControl>().CheckToStartNextRound();
                }
                    if (_hit.transform.tag == "TurrentSpawn")
                {
                    CurrentTurretSpawnPoint = _hit.transform;
                    if (!_buildMenuUp)
                    {
                        _buildMenuUp = true;
                    }
                    ToggleBuildMenu(_buildMenuUp);
                    SelectedTurretSpawnLocation.transform.position = _hit.transform.position;
                }
                if (_hit.transform.tag == "BuildingSpawn")
                {
                    _selectedTurretType = _hit.transform.GetComponent<BuildInfo>().projectileTypes;
                    

                    switch (_selectedTurretType)
                    {
                        case (ProjectileTypes.Fire):
                            _gameController.CurrentSelectedBuildingCost = _buildingInfo.FireBuildingLevelsCosts[_buildingInfo.BuildingLevels["Fire"]];
                            break;
                        case (ProjectileTypes.Ice):
                            _gameController.CurrentSelectedBuildingCost = _buildingInfo.IceBuildingLevelsCosts[_buildingInfo.BuildingLevels["Ice"]];
                            break;
                        case (ProjectileTypes.Earth):
                            _gameController.CurrentSelectedBuildingCost = _buildingInfo.EarthBuildingLevelsCosts[_buildingInfo.BuildingLevels["Earth"]];
                            break;
                        case (ProjectileTypes.Poison):
                            _gameController.CurrentSelectedBuildingCost = _buildingInfo.PoisonBuildingLevelsCosts[_buildingInfo.BuildingLevels["Poison"]];
                            break;
                    }
                }
                if (_hit.transform.tag == "BuildButton")
                {
                    if (_gameController.CurrentSelectedBuildingCost <= _gameController.MoneyLeft)
                    {
                        switch (_selectedTurretType)
                        {
                            case (ProjectileTypes.Fire):
                                Instantiate(FireTurret, CurrentTurretSpawnPoint.position, Quaternion.identity);
                                _gameController.NumberOfFireTurrets++;
                                break;
                            case (ProjectileTypes.Ice):
                                Instantiate(IceTurret, CurrentTurretSpawnPoint.position, Quaternion.identity);
                                _gameController.NumberOfIceTurrets++;
                                break;
                            case (ProjectileTypes.Earth):
                                Instantiate(EarthTurret, CurrentTurretSpawnPoint.position, Quaternion.identity);
                                _gameController.NumberOfEarthTurrets++;
                                break;
                            case (ProjectileTypes.Poison):
                                Instantiate(PoisonTurret, CurrentTurretSpawnPoint.position, Quaternion.identity);
                                _gameController.NumberOfPoisonTurrets++;
                                break;
                        }
                        _gameController.MoneyLeft -= _gameController.CurrentSelectedBuildingCost;
                        _gameController.UpdateListOfTurrets();
                        _rhythmValues.SetAllNotes();
                    }
                    else
                    {

                    }
                }
                else
                {
                    _buildMenuUp = false;
                    //ToggleBuildMenu(_buildMenuUp);
                }

                }

            }
        ConfirmBuildButtonActive();
     }

    void ToggleBuildMenu(bool enable)
    {
        if (enable)
        {
            if (!BuildMenu.activeSelf)
            {
                BuildMenu.SetActive(true);
            }
        }
        else
        {
            if (BuildMenu.activeSelf)
            {
                BuildMenu.SetActive(false);
            }
        }
        
    }

    void ConfirmBuildButtonActive()
    {
        if(CurrentTurretSpawnPoint == null)
        {
            if (BuildBuildingButton.activeSelf)
            {
                BuildBuildingButton.SetActive(false);
            }
        }
        else
        {
            if (!BuildBuildingButton.activeSelf)
            {
                BuildBuildingButton.SetActive(true);
            }
        }
    }
}
