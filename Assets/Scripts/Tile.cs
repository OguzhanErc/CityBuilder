using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    //Building reference that each tile will have for each building.
    public Building buildingRef;


    public ObstacleType obstacleType;


    bool isStarterTile = true;
    //The stuff that the tile is being occupied by.
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }
    #region Methods
    public void SetOccupied(ObstacleType t)
    {
        obstacleType = t;
    }

    public void SetOccupied(ObstacleType t, Building b)
    {
        obstacleType = t;
        buildingRef = b;
    }
    public void CleanTile()
    {
        obstacleType = ObstacleType.None;
    }

    public void StarterTileValue(bool value)
    {
        isStarterTile = value;
    }
    #endregion
    #region Booleans
    public bool IsOccupied
    {
        get
        {
            return obstacleType != ObstacleType.None;
        }
    }

    public bool CanSpawnObstacle
    {
        get
        {
            return !isStarterTile;
        }
    }
    #endregion
}
