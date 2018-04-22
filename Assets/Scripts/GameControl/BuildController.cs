using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour {

    private RaycastHit _hit;
    private RaycastHit _hitBuilding;
    public Transform CurrentTurretSpawnPoint;
    private bool _buildMenuUp = false;
    public GameObject BuildMenu;
    public GameObject FireTurret, IceTurret, PoisonTurret, EarthTurret;
    public GameObject TestGameObject;
    private ProjectileTypes _selectedTurretType;
    private GameController _gameController;
    private UpgradeController _upgradeController;
    private RythmValues _rhythmValues;
    private BuildingInfo _buildingInfo;
    public GameObject SelectedTurretSpawnLocation;
    public GameObject BuildBuildingButton;
    public Transform SelectedTurretSpawnLocationOffScreen;


    public LayerMask LayerMask;
    void Start()
    {
        _gameController = GetComponent<GameController>();
        _buildingInfo = GetComponent<BuildingInfo>();
        _rhythmValues = FindObjectOfType<RythmValues>();
        _upgradeController = FindObjectOfType<UpgradeController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit, 100.0F, LayerMask))
            {
                if (_hit.transform.tag == "NextRoundButton")
                {
                    _hit.transform.gameObject.GetComponent<NextRoundControl>().CheckToStartNextRound();
                }
                if (_hit.transform.tag == "UpgradeButton")
                {
                    _hit.transform.gameObject.GetComponent<UpgradeController>().CheckIfUpgradePossible();
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
                            _upgradeController.SelectedElementText.text = "Fire";
                            
                            break;
                        case (ProjectileTypes.Ice):
                            _gameController.CurrentSelectedBuildingCost = _buildingInfo.IceBuildingLevelsCosts[_buildingInfo.BuildingLevels["Ice"]];
                            _upgradeController.SelectedElementText.text = "Ice";
                            break;
                        case (ProjectileTypes.Earth):
                            _gameController.CurrentSelectedBuildingCost = _buildingInfo.EarthBuildingLevelsCosts[_buildingInfo.BuildingLevels["Earth"]];
                            _upgradeController.SelectedElementText.text = "Earth";
                            break;
                        case (ProjectileTypes.Poison):
                            _gameController.CurrentSelectedBuildingCost = _buildingInfo.PoisonBuildingLevelsCosts[_buildingInfo.BuildingLevels["Poison"]];
                            _upgradeController.SelectedElementText.text = "Poison";
                            break;
                    }
                    _upgradeController.UpdateUpgradeText();
                }
                if (_hit.transform.tag == "BuildButton")
                {
                    Vector3 proposedSpawnPoint = new Vector3(CurrentTurretSpawnPoint.position.x, 10F, CurrentTurretSpawnPoint.position.z);
                    Ray buildRay = new Ray(proposedSpawnPoint, Vector3.down);
                    Debug.DrawLine(proposedSpawnPoint, Vector3.down);
                    if (Physics.Raycast(buildRay, out _hitBuilding, 100.0F, LayerMask))
                    {
                            if (_hitBuilding.transform == null || _hitBuilding.transform.tag != "Building")
                            {
                                if (_gameController.CurrentSelectedBuildingCost <= _gameController.MoneyLeft)
                                {
                                 GameObject TestGO = Instantiate(TestGameObject, CurrentTurretSpawnPoint.position, Quaternion.identity) as GameObject;
                                if (!TestGO.GetComponent<TestGameObject>().IsInfringing)
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
                                    CurrentTurretSpawnPoint = null;
                                    SelectedTurretSpawnLocation.transform.position = SelectedTurretSpawnLocationOffScreen.position;
                                }

                                else
                                {
                                    Debug.Log("Can't build here!!!");
                                }
                                    
                                }
                                else
                                {

                                }
                            }
                        else
                        {
                            Debug.Log(_hitBuilding.transform.name);
                        }
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
