﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour {

    public Dictionary<string, int> BuildingLevels;
    public Dictionary<int, int> FireBuildingLevelsCosts;
    public Dictionary<int, int> IceBuildingLevelsCosts;
    public Dictionary<int, int> PoisonBuildingLevelsCosts;
    public Dictionary<int, int> EarthBuildingLevelsCosts;

    public Dictionary<int, int> FireBuildingUpgradeCosts;
    public Dictionary<int, int> IceBuildingUpgradeCosts;
    public Dictionary<int, int> PoisonBuildingUpgradeCosts;
    public Dictionary<int, int> EarthBuildingUpgradeCosts;


    public int CurrentFireBuildingLevel;
    public int CurrentIceBuildingLevel;
    public int CurrentPoisonBuildingLevel;
    public int CurrentEarthBuildingLevel;

    void Start()
    {
        BuildingLevels = new Dictionary<string, int>();
        BuildingLevels.Add("Fire", 0);
        BuildingLevels.Add("Ice", 0);
        BuildingLevels.Add("Poison", 0);
        BuildingLevels.Add("Earth", 0);

        FireBuildingLevelsCosts = new Dictionary<int, int>();
        FireBuildingLevelsCosts.Add(0, 100);
        FireBuildingLevelsCosts.Add(1, 200);
        FireBuildingLevelsCosts.Add(2, 300);
        FireBuildingLevelsCosts.Add(3, 400);

        IceBuildingLevelsCosts = new Dictionary<int, int>();
        IceBuildingLevelsCosts.Add(0, 50);
        IceBuildingLevelsCosts.Add(1, 100);
        IceBuildingLevelsCosts.Add(2, 150);
        IceBuildingLevelsCosts.Add(3, 200);

        PoisonBuildingLevelsCosts = new Dictionary<int, int>();
        PoisonBuildingLevelsCosts.Add(0, 80);
        PoisonBuildingLevelsCosts.Add(1, 160);
        PoisonBuildingLevelsCosts.Add(2, 250);
        PoisonBuildingLevelsCosts.Add(3, 350);

        EarthBuildingLevelsCosts = new Dictionary<int, int>();
        EarthBuildingLevelsCosts.Add(0, 150);
        EarthBuildingLevelsCosts.Add(1, 250);
        EarthBuildingLevelsCosts.Add(2, 400);
        EarthBuildingLevelsCosts.Add(3, 500);

        FireBuildingUpgradeCosts = new Dictionary<int, int>();
        FireBuildingUpgradeCosts.Add(0, 500);
        FireBuildingUpgradeCosts.Add(1, 750);
        FireBuildingUpgradeCosts.Add(2, 1000);

        IceBuildingUpgradeCosts = new Dictionary<int, int>();
        IceBuildingUpgradeCosts.Add(0, 250);
        IceBuildingUpgradeCosts.Add(1, 500);
        IceBuildingUpgradeCosts.Add(2, 800);

        PoisonBuildingUpgradeCosts = new Dictionary<int, int>();
        PoisonBuildingUpgradeCosts.Add(0, 225);
        PoisonBuildingUpgradeCosts.Add(1, 400);
        PoisonBuildingUpgradeCosts.Add(2, 700);

        EarthBuildingUpgradeCosts = new Dictionary<int, int>();
        EarthBuildingUpgradeCosts.Add(0, 600);
        EarthBuildingUpgradeCosts.Add(1, 1200);
        EarthBuildingUpgradeCosts.Add(2, 1800);
    }

    void Update()
    {
        int temp;
        if (BuildingLevels.TryGetValue("Fire", out temp))
        {
            CurrentFireBuildingLevel = temp;
        }
        if (BuildingLevels.TryGetValue("Ice", out temp))
        {
            CurrentIceBuildingLevel = temp;
        }
        if (BuildingLevels.TryGetValue("Poison", out temp))
        {
            CurrentPoisonBuildingLevel = temp;
        }
        if (BuildingLevels.TryGetValue("Earth", out temp))
        {
            CurrentEarthBuildingLevel = temp;
        }

    }
}
