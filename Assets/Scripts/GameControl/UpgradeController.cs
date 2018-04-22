using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeController : MonoBehaviour {

    public TextMeshPro SelectedElementText;
    public TextMeshPro CostToUpgradeText;
    BuildingInfo _buildingInfo;
    private int _costOfUpgrade;
    GameController _gameController;

	void Start ()
    {
        SelectedElementText.text = "";
        _buildingInfo = FindObjectOfType<BuildingInfo>();
        _gameController = FindObjectOfType<GameController>();
    }

    public void UpdateUpgradeText()
    {
        if (SelectedElementText.text != "")
        {
            switch (SelectedElementText.text)
            {
                case ("Fire"):
                    _costOfUpgrade = (_buildingInfo.FireBuildingUpgradeCosts[_buildingInfo.CurrentFireBuildingLevel]);
                    break;
                case ("Ice"):
                    _costOfUpgrade = (_buildingInfo.IceBuildingUpgradeCosts[_buildingInfo.CurrentIceBuildingLevel]);
                    break;
                case ("Poison"):
                    _costOfUpgrade = (_buildingInfo.PoisonBuildingUpgradeCosts[_buildingInfo.CurrentPoisonBuildingLevel]);
                    break;
                case ("Earth"):
                    _costOfUpgrade = (_buildingInfo.EarthBuildingUpgradeCosts[_buildingInfo.CurrentEarthBuildingLevel]);
                    break;
            }
            CostToUpgradeText.text = _costOfUpgrade.ToString();
        }
    }

    public void CheckIfUpgradePossible()
    {
        if(_costOfUpgrade <= _gameController.MoneyLeft)
        {
            switch (SelectedElementText.text)
            {
                case ("Fire"):
                    _buildingInfo.CurrentFireBuildingLevel++;
                    break;
                case ("Ice"):
                    _buildingInfo.CurrentIceBuildingLevel++;
                    break;
                case ("Poison"):
                    _buildingInfo.CurrentPoisonBuildingLevel++;
                    break;
                case ("Earth"):
                    _buildingInfo.CurrentEarthBuildingLevel++;
                    break;
            }
            _gameController.MoneyLeft -= _costOfUpgrade;
        }
    }

}
