using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum, maximum;
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 8, rows = 8;
    public Count wallCount = new Count(5, 9);
    public Count itemCount = new Count(1, 5);

    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] itemTiles;
    public GameObject[] enemyTiles;
    public GameObject[] boardWallTiles;

    private Transform boardHolder;
    private List<Vector2> gridPos = new List<Vector2>();

    void InitialiseList()
    {
        gridPos.Clear();
        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPos.Add(new Vector2(x, y));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = boardWallTiles[Random.Range(0, boardWallTiles.Length)];
                }
                GameObject instance = Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector2 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPos.Count);
        Vector2 randomPos = gridPos[randomIndex];
        gridPos.RemoveAt(randomIndex);
        return randomPos;
    }

    void LayoutObjectRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, minimum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector2 randomPos = RandomPosition();
            GameObject tile = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tile, randomPos, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutObjectRandom(itemTiles, itemCount.minimum, itemCount.maximum);
        int EnemyCount = (int)Mathf.Log(level, 2f) + 5 + level;
        LayoutObjectRandom(enemyTiles, EnemyCount, EnemyCount);
        Instantiate(exit, new Vector2(columns - 1, rows - 1), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
