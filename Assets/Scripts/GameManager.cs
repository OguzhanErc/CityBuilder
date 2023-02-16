using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]

    [Space(8)]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1;
    public float tileEndHeight = 1;


    [Header("Resources")]

    [Space(8)]

    public GameObject woodPrefab;
    public GameObject rockPrefab;

    [Range(0, 1)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 0;


    private void Start()
    {
        CreateLevel();
    }
    /// <summary>
    /// Create our grid depending on out level width and length.
    ///</summary>
    public void CreateLevel()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                TileObject spawnedTile = SpawnTile(x * tileSize, z * tileSize);

                if (x < xBounds || z < zBounds || z >= (levelLength - zBounds) || x >= (levelWidth - xBounds))
                {
                    //We can spawn an obstacle in there.
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;

                    if (spawnObstacle)
                    {
                        //Debug.Log("Spawned obstacle on" + spawnedTile.gameObject.name);
                        //Handle the spawning obstacle functionality.

                        //DEBUG (DELETE LATER)
                        //spawnedTile.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

                        spawnedTile.data.SetOccupied(Tile.ObstacleType.Resource);
                        SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);

                    }
                }
            }
        }
    }
    /// <summary>
    /// Spawns and returns a tileObject.
    /// </summary>
    /// <param name="xPos">X Position inside the world</param>
    /// <param name="zPos">Z Position inside the world</param>
    /// <returns></returns>
    TileObject SpawnTile(float xPos, float zPos)
    {
        //This will spawn the tile
        GameObject tmpTile = Instantiate(tilePrefab);


        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);

        tmpTile.name = "Tile" + xPos + " - " + zPos;

        //Check if the tile is able to hold an obstacle.

        //TODO Make this to not get a component.
        return tmpTile.GetComponent<TileObject>();
    }

    /// <summary>
    /// Will spawn a resource obstacle directly in the coordinates
    /// </summary>
    /// <param name="xPos">X Position of the obstacle</param>
    /// <param name="zPos">Z Position of the obstacle</param>
    public void SpawnObstacle(float xPos, float zPos)
    {
        //It has a 50% of spawning a wood obstacle
        bool isWood = Random.value <= .5f;

        GameObject spawnedObstacle = null;

        //Check whether we spawn a wood obstacle or a stone obstacle.
        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefab);
        }
        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
    }
}
