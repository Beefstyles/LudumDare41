using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour {

    private RaycastHit _hit;
    public Transform CurrentTurretSpawnPoint;
    private bool _buildMenuUp = false;
    public GameObject BuildMenu;
    public GameObject FireTurret, IceTurret, PoisonTurret, EarthTurret;

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
                else
                {
                    _buildMenuUp = false;
                    //ToggleBuildMenu(_buildMenuUp);
                }
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
