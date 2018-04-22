using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmValues : MonoBehaviour {

    public int[] FireValues = new int[12];
    public int[] IceValues = new int[12];
    public int[] PoisonValues = new int[12];
    public int[] EarthValues = new int[12];

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
        switch (_buildingInfo.CurrentIceBuildingLevel)
        {
            case (0):
                //IceValues = new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0 };
                IceValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case (1):
                IceValues = new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
                break;
            case (2):
                IceValues = new int[] { 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0 };
                break;
            case (3):
                IceValues = new int[] { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 };
                break;
        }
    }

    void UpdatePoisonNotes()
    {
        switch (_buildingInfo.CurrentPoisonBuildingLevel)
        {
            case (0):
                //PoisonValues = new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0 };
                PoisonValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case (1):
                PoisonValues = new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
                break;
            case (2):
                PoisonValues = new int[] { 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0 };
                break;
            case (3):
                PoisonValues = new int[] { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 };
                break;
        }
    }

    void UpdateEarthNotes()
    {
        switch (_buildingInfo.CurrentEarthBuildingLevel)
        {
            case (0):
                //EarthValues = new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0 };
                EarthValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case (1):
                EarthValues = new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
                break;
            case (2):
                EarthValues = new int[] { 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0 };
                break;
            case (3):
                EarthValues = new int[] { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 };
                break;
        }
    }

    IEnumerator DelaySettingOfNotes()
    {
        yield return new WaitForSeconds(0.5F);
        SetAllNotes();
    }

    void SetAllNotes()
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
                    if (IceValues[i] == 0)
                    {
                        if (rythymSection.IceNote.activeSelf)
                        {
                            rythymSection.IceNote.SetActive(false);
                        }
                    }
                    else
                    {
                        if (!rythymSection.IceNote.activeSelf)
                        {
                            rythymSection.IceNote.SetActive(true);
                        }
                    }
                    if (PoisonValues[i] == 0)
                    {
                        if (rythymSection.PoisionNote.activeSelf)
                        {
                            rythymSection.PoisionNote.SetActive(false);
                        }
                    }
                    else
                    {
                        if (!rythymSection.PoisionNote.activeSelf)
                        {
                            rythymSection.PoisionNote.SetActive(true);
                        }
                    }
                    if (EarthValues[i] == 0)
                    {
                        if (rythymSection.EarthNote.activeSelf)
                        {
                            rythymSection.EarthNote.SetActive(false);
                        }
                    }
                    else
                    {
                        if (!rythymSection.EarthNote.activeSelf)
                        {
                            rythymSection.EarthNote.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
