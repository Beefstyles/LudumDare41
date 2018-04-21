using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPopulator : MonoBehaviour {

    public GameObject StartPoint, EndPoint, RoadBlock, WayPointBlock, TurrentSpawnBlock;
    public Transform LevelObjectsSpawnParent;
    public GameObject LevelGrid;
    private Renderer _levelGridRenderer;
    private float _xPosition, _yPosition;
    private Vector2 _objectPosition;
	// Use this for initialization
	void Start () {
		
	}

    public IEnumerator PopulateLevel(string[] levelText, int gridXSize, int gridYSize)
    {
        LevelGrid.transform.localScale = new Vector3(gridXSize, gridYSize, 1F);
        _levelGridRenderer = LevelGrid.GetComponent<Renderer>();
        _levelGridRenderer.material.mainTextureScale = new Vector2(gridXSize, gridYSize);
        for (int i = 0; i < levelText.Length; i++)
        {
            char[] levelTextChar = levelText[i].ToCharArray();
            for (int j = 0; j < levelText.Length; j++)
            {
                _xPosition = j - (gridYSize / 2 - 0.5F);
                _yPosition = (gridYSize / 2 - 0.5F) - i;
                _objectPosition = new Vector2(_xPosition, _yPosition);
            }
        }
    }
}
