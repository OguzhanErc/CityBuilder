using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [Header("Resources")]

    [Space(8)]


    //Sets the max amount of wood.
    public int maxWood;
    int wood = 0;

    //Sets the max amount of stone.
    public int maxStone;
    int stone = 0;

    //Sets the max amount of premium currency.
    public int maxPremiumCurrency;
    int premiumC = 0;

    //Sets the max amount of standarcurrency.
    public int maxStandardCurrency;
    int standardC = 0;

    public static ResourceManager Instance;

    public bool debugBool = false;

    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        if (debugBool)
        {
            PrintCurrentResources();
            debugBool = false;
        }
    }
    /// <summary>
    /// Adds more wood to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing wood</param>

    public void AddWood(int amount)
    {
        wood += amount;

        //TODO: Update the wood UI to show the correct amount of wood.
    }

    /// <summary>
    /// Adds more stone to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing stone</param>
    public void AddStone(int amount)
    {
        stone += amount;

        //TODO: Update the stone UI to show the correct amount of stone.
    }

    /// <summary>
    /// Adds more premium currency to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing premium currency</param>
    public void AddPremiumC(int amount)
    {
        premiumC += amount;

        //TODO: Update the premium currency UI to show the correct amount of premium currency.
    }

    /// <summary>
    /// Adds more standard currency to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing standard currency</param>
    public void AddStandardC(int amount)
    {
        standardC += amount;

        //TODO: Update the standard currency UI to show the correct amount of standard currency.
    }

    void PrintCurrentResources()
    {
        Debug.Log("wood" + wood);
        Debug.Log("stone" + stone);
        Debug.Log("standard" + standardC);
        Debug.Log("premium" + premiumC);
    }

}
