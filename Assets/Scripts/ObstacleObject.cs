using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int resourceAmount = 10;
    /// <summary>
    /// this is a method that it is called whenever the item has been clicked or tapped.
    /// WOrks on mobile and PC.
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);

        //OnClick Event
        bool usedResource = false;

        //We can call directly the method that adds the resource

        switch (obstacleType)
        {
            case ObstacleType.Wood:
                usedResource = ResourceManager.Instance.AddWood(resourceAmount);
                break;

            case ObstacleType.Rock:
                usedResource = ResourceManager.Instance.AddStone(resourceAmount);
                break;
        }
        if (usedResource)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Could not destroy because inventory is full");
        }
    }
    public enum ObstacleType
    {
        Wood,
        Rock
    }
}
