using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using LitJson;

public class LevelReader : MonoBehaviour {

    private string _jsonLevelData;
    private string[] _levelArray;
    private int _gridXSize, _gridYSize;
    private decimal _initialMoney;
    private int _numberOfRounds;

    private LevelPopulator _levelPopulator;


    /*
     * Title": "FirstLevel",
        "GridXSize": 10,
        "GridYSize": 20,
        "Money": 50000.0,
        "NumberOfRounds":5,
        "LevelGridArray":
     */

    public class JSONLevelDataParser
    {
        /*
        * Title": "FirstLevel",
       "GridXSize": 10,
       "GridYSize": 20,
       "Money": 50000.0,
       "NumberOfRounds":5,
       "LevelGridArray":
        */
        public string Title;
        public int GridXSize, GridYSize;
        public decimal Money;
        public int NumberOfRounds;
        public string[] LevelGridArray;
    }

    void Awake()
    {
        try
        {
            _jsonLevelData = File.ReadAllText(Application.dataPath + "/Resources/Levels/Level_1.json");
            ParseJSONLevelDataToClass();
            _levelPopulator = GetComponent<LevelPopulator>();
            StartCoroutine(_levelPopulator.PopulateLevel(_levelArray, _gridXSize, _gridYSize));
        }
        catch (Exception e)
        {
            Debug.LogError("Error in loading the json level data file: " + e.Message);
        }
    }

    private void ParseJSONLevelDataToClass()
    {
        try
        {
            JSONLevelDataParser levelData = JsonMapper.ToObject<JSONLevelDataParser>(_jsonLevelData);
            _levelArray = levelData.LevelGridArray;
            _gridXSize = levelData.GridXSize;
            _gridYSize = levelData.GridYSize;
            _initialMoney = levelData.Money;
            _numberOfRounds = levelData.NumberOfRounds;
        }
        catch(Exception e)
        {
            Debug.LogError("Failed in parsing the JSON data: " + e.Message);
        }
    }
}

