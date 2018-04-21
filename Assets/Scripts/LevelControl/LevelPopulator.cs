using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPopulator : MonoBehaviour {

    public GameObject StartPoint, EndPoint, RoadBlock, WayPointBlock, TurrentSpawnBlock, GridRefBlock;
    public Transform LevelObjectsSpawnParent, GridReferencesSpawnParent;
    public GameObject LevelGrid;
    private Renderer _levelGridRenderer;
    private float _xPosition, _zPosition;
    private Vector3 _objectPosition;

    public IEnumerator PopulateLevel(string[] levelText, int gridXSize, int gridZSize)
    {
        LevelGrid.transform.localScale = new Vector3(gridXSize / 10, 1F, gridZSize / 10);
        _levelGridRenderer = LevelGrid.GetComponent<Renderer>();
        _levelGridRenderer.material.mainTextureScale = new Vector2(gridXSize, gridZSize);
        for (int i = 0; i < levelText.Length; i++)
        {
            char[] levelTextChar = levelText[i].ToCharArray();
            for (int j = 0; j < levelText.Length; j++)
            {
                //_xPosition = j - (gridZSize / 2 - 0.5F);
                _xPosition = j - (gridZSize / 2);
                //_zPosition = (gridZSize / 2 - 0.5F) - i;
                _zPosition = (gridZSize / 2) - i;
                _objectPosition = new Vector3(_xPosition, 1, _zPosition);

                GameObject gridRefBlock = Instantiate(GridRefBlock, _objectPosition, Quaternion.identity) as GameObject;
                gridRefBlock.name = "(" + _xPosition + "," + _zPosition + ")";
                gridRefBlock.transform.SetParent(GridReferencesSpawnParent);
                yield return new WaitForSeconds(0.001F);

                switch (levelTextChar[j])
                {
                    case ('S'):
                        SpawnObject(StartPoint, _objectPosition, "StartPoint");
                        break;
                    case ('E'):
                        SpawnObject(EndPoint, _objectPosition, "EndPoint");
                        break;
                    case ('R'):
                        SpawnObject(RoadBlock, _objectPosition, "RoadBlock");
                        break;
                    case ('W'):
                        SpawnObject(WayPointBlock, _objectPosition, "WayPoint");
                        break;
                    case ('T'):
                        SpawnObject(TurrentSpawnBlock, _objectPosition, "TurrentSpawnLocation");
                        break;
                }
                yield return new WaitForSeconds(0.05F);
            }
        }
    }

    private void SpawnObject(GameObject objectToSpawn, Vector2 position, string name)
    {
        GameObject cloneObject = Instantiate(objectToSpawn, position, Quaternion.identity);
        cloneObject.name = name;
        cloneObject.transform.SetParent(LevelObjectsSpawnParent);
    }
}
