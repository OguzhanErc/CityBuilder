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

    public int Wood { get => wood; set => wood = value; }
    public int Stone { get => stone; set => stone = value; }
    public int PremiumC { get => premiumC; set => premiumC = value; }
    public int StandardC { get => standardC; set => standardC = value; }

    private void Awake()
    {
        //Initializing the singleton pattern (not for production)
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
    public bool AddWood(int amount)
    {
        if ((wood + amount)<=maxWood)
        {
            Wood += amount;

            //Updates the corresponding UI.
            UIManager.instance.UpdateWoodUI(Wood, maxWood);
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Adds more stone to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing stone</param>
    public bool AddStone(int amount)
    {
        if ((stone + amount)<=maxStone)
        {
            Stone += amount;

            //Updates the corresponding UI.
            UIManager.instance.UpdateStoneUI(Stone, maxStone);
            return true;
        }
        else
        {
            return false;
        }       
    }


    /// <summary>
    /// Adds more premium currency to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing premium currency</param>
    public bool AddPremiumC(int amount)
    {
        if ((premiumC + amount)<=maxPremiumCurrency)
        {
            PremiumC += amount;

            //Updates the corresponding UI.
            UIManager.instance.UpdatePremiumCUI(PremiumC, maxPremiumCurrency);
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Adds more standard currency to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing standard currency</param>
    public bool AddStandardC(int amount)
    {
        if ((standardC + amount)<=maxStandardCurrency)
        {
            StandardC += amount;

            //Updates the corresponding UI.
            UIManager.instance.UpdateStandardCUI(StandardC, maxStandardCurrency);
            return true;
        }
        else
        {
            return false;
        }      
    }

    void PrintCurrentResources()
    {
        Debug.Log("wood" + Wood);
        Debug.Log("stone" + Stone);
        Debug.Log("standard" + StandardC);
        Debug.Log("premium" + PremiumC);
    }

}
