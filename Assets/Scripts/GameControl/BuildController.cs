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
    private BuildingInfo _buildingInfo;

    void Start()
    {
        _gameController = GetComponent<GameController>();
        _buildingInfo = GetComponent<BuildingInfo>();
    }
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit, 100.0F))
            {
                if(_hit.transform.tag == "TurrentSpawn")
                {
                    CurrentTurretSpawnPoint = _hit.transform;
                    if (!_buildMenuUp)
                    {
                        _buildMenuUp = true;
                    }
                    ToggleBuildMenu(_buildMenuUp);
                    Debug.Log("Can spawn here");
                }
                if(_hit.transform.tag == "BuildingSpawn")
                {
                    _selectedTurretType = _hit.transform.GetComponent<BuildInfo>().projectileTypes;
                   
                    switch (_selectedTurretType)
                    {
                        case (ProjectileTypes.Fire):
                            //Debug.Log(_buildingInfo.FireBuildingLevelsCosts[_buildingInfo.BuildingLevels["Fire"]]);
                            _gameController.CurrentSelectedBuildingCost = _buildingInfo.FireBuildingLevelsCosts[_buildingInfo.BuildingLevels["Fire"]];
                            break;
                        case (ProjectileTypes.Ice):
                            break;
                        case (ProjectileTypes.Earth):
                            break;
                        case (ProjectileTypes.Poison):
                            break;
                    }
                }
                else
                {
                    _buildMenuUp = false;
                    //ToggleBuildMenu(_buildMenuUp);
                }
                Debug.Log(_hit.transform.tag);
            }
            
        }
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
}
