using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmValues : MonoBehaviour {

    public int[] FireValues = new int[12];
    public int[] Note2Values = new int[12];
    public int[] Note3Values = new int[12];
    public int[] Note4Values = new int[12];

    BuildingInfo _buildingInfo;

	void Start ()
    {
        _buildingInfo = FindObjectOfType<BuildingInfo>();
    }
	
	void Update ()
    {
        
	}

    void UpdateFireNotes()
    {
        switch (_buildingInfo.CurrentFireBuildingLevel)
        {
            case (0):
                FireValues = new int [] { 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0};
                break;
            case (1):
                FireValues = new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
                break;
            case (2):
                FireValues = new int[] { 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0 };
                break;
            case (3):
                FireValues = new int[] { 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1 };
                break;
        }
    }
}
