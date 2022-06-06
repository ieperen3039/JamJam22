using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBehaviour : MonoBehaviour
{
    public int Inhabitants;
    public float waterUsePerInhabitantPerSecond;

    public float WaterPriceAllBuy;
    public float WaterPriceZeroBuy;

    public WorldScript WorldScript;

    private float ownWaterProductionPerSecond;
    private float droughtFraction; // how bad the lack of water is

    // Start is called before the first frame update
    void Start()
    {
        ownWaterProductionPerSecond = Inhabitants * waterUsePerInhabitantPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        float totalPotentialWaterProduction = ownWaterProductionPerSecond / Time.deltaTime;
        float waterProduced = totalPotentialWaterProduction * GetFractionOfProductionUsed();
        float waterConsumed = Inhabitants * (waterUsePerInhabitantPerSecond / Time.deltaTime);
        float waterShortage = waterProduced - waterConsumed;

        WorldScript.BuyWater(waterShortage);
    }

    // based purely on water price per liter
    float GetFractionOfProductionUsed()
    {
        float priceDecicionGap = WaterPriceZeroBuy - WaterPriceAllBuy;
        float priceAboveBuyAll = WorldScript.WaterPricePerLiter - WaterPriceAllBuy;
        float rawFraction = priceDecicionGap / priceAboveBuyAll;

        return Mathf.Clamp(rawFraction, 0, 1);
    }
}
