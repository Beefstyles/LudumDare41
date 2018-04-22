using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmValues : MonoBehaviour {

    public int[] FireValues = new int[12];
    public int[] Note2Values = new int[12];
    public int[] Note3Values = new int[12];
    public int[] Note4Values = new int[12];

    RhythmSection[] _rhythmSections;


    BuildingInfo _buildingInfo;

	void Start ()
    {
        _buildingInfo = FindObjectOfType<BuildingInfo>();
        _rhythmSections = GetComponentsInChildren<RhythmSection>();
        UpdateFireNotes();
        StartCoroutine("DelaySettingOfNotes");
    }
	
	void Update ()
    {
        

    }

    void UpdateFireNotes()
    {
        switch (_buildingInfo.CurrentFireBuildingLevel)
        {
            case (0):
                FireValues = new int [] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0};
                break;
            case (1):
                FireValues = new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
                break;
            case (2):
                FireValues = new int[] { 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0 };
                break;
            case (3):
                FireValues = new int[] { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 };
                break;
        }
    }

    void UpdateIceNotes()
    {
        switch (_buildingInfo.CurrentFireBuildingLevel)
        {
            case (0):
                FireValues = new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0 };
                break;
            case (1):
                FireValues = new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
                break;
            case (2):
                FireValues = new int[] { 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0 };
                break;
            case (3):
                FireValues = new int[] { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 };
                break;
        }
    }

    void UpdatePoisonNotes()
    {
        switch (_buildingInfo.CurrentFireBuildingLevel)
        {
            case (0):
                FireValues = new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0 };
                break;
            case (1):
                FireValues = new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
                break;
            case (2):
                FireValues = new int[] { 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0 };
                break;
            case (3):
                FireValues = new int[] { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 };
                break;
        }
    }

    IEnumerator DelaySettingOfNotes()
    {
        yield return new WaitForSeconds(0.5F);
        SetFireNotes();
    }

    void SetFireNotes()
    {
        foreach (var rythymSection in _rhythmSections)
        {
            for (int i = 0; i < FireValues.Length; i++)
            {
                if (rythymSection.RhythmSectionNumber == i)
                {
                    if(FireValues[i] == 0)
                    {
                        if (rythymSection.FireNote.activeSelf)
                        {
                            rythymSection.FireNote.SetActive(false);
                        }
                    }
                    else
                    {
                        if (!rythymSection.FireNote.activeSelf)
                        {
                            rythymSection.FireNote.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
