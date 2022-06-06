using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : MonoBehaviour
{
    public float waterPerTick;
    public float moneyPerTick;
    public float energyPerTick;
    public float buildingCost;

    public float moneyResources;
    public float energyResources;

    public PlayerInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory.PrintHello();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateWater()
    {
        if (inventory.Money > moneyPerTick)
        {
            inventory.RemoveMoney(moneyPerTick);
            inventory.AddWater(waterPerTick);
        }
    }
}
