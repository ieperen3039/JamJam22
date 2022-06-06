using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CityBehaviour : MonoBehaviour
{
    public int Inhabitants;
    public float waterUsePerInhabitantPerSecond;

    public float WaterPriceAllBuy;
    public float WaterPriceZeroBuy;
    public float WaterShortageEffect = 0.1f; // what fraction of shortage is applied per second
    public float WaterShortageMaxOwnProductionPoint = 0.2f; // at which droughtFraction point do we maximize our own production
    public float OwnWaterProductionIncrementFactor = 0.01f; // absolute production increase per second per inhabitant when more water is desired
    public float MaxGrowthFactorPerSecond = 0.05f;
    public float MaxGrowthLossFactorPerSecond = 0.01f;
    public float GrowthCutoffValue = 0.3f;

    public WorldScript WorldScript;
    public UnityEvent InhabitantChangeListeners;

    public float ownWaterProductionPerSecond { get; private set; }
    public float draughtFraction { get; private set; } // how bad the lack of water is

    private float growthProgress;

    // Start is called before the first frame update
    void Start()
    {
        ownWaterProductionPerSecond = Inhabitants * waterUsePerInhabitantPerSecond;
        draughtFraction = 0.0f;
        growthProgress = 0.0f;
    }

    void Update()
    {
        float factionOfPeopleProducingWater = GetFractionOfProductionUsed();
        float waterProducedPerSecond = ownWaterProductionPerSecond * factionOfPeopleProducingWater;
        float waterProduced = waterProducedPerSecond / Time.deltaTime;
        float waterConsumedPerSecond = Inhabitants * waterUsePerInhabitantPerSecond;
        float waterConsumed = waterConsumedPerSecond / Time.deltaTime;
        float waterRequired = waterProduced - waterConsumed;

        // try to buy the water
        float waterObtained = WorldScript.BuyWater(waterRequired);
        float waterShortage = (waterRequired - waterObtained);

        if (waterShortage > 0)
        {
            // we could not buy all the required water
            float effectThisFrame = WaterShortageEffect * Time.deltaTime;
            draughtFraction = (1 - effectThisFrame) * draughtFraction + effectThisFrame * waterShortage;
        }

        float desiredOwnProductionPerSecond = waterUsePerInhabitantPerSecond * factionOfPeopleProducingWater;
        if (desiredOwnProductionPerSecond > ownWaterProductionPerSecond)
        {
            ownWaterProductionPerSecond += (Inhabitants * OwnWaterProductionIncrementFactor) / Time.deltaTime;
        }

        // calculate growth/shrink
        float change;
        if (draughtFraction < GrowthCutoffValue)
        {
            // growth
            float draughtEffect = draughtFraction / GrowthCutoffValue;
            change = Inhabitants * MaxGrowthFactorPerSecond * draughtEffect;
        }
        else
        {
            // shrink
            float effectRange = (1 - GrowthCutoffValue);
            float effectValue = (draughtFraction - GrowthCutoffValue);
            float draughtEffect = effectValue / effectRange;
            change = Inhabitants * MaxGrowthLossFactorPerSecond * draughtEffect * -1;
        }
        change *= Time.deltaTime;
        growthProgress += change;

        // apply growth/shrink
        bool inhabitantsChange = false;
        while (growthProgress > 1)
        {
            Inhabitants++;
            growthProgress -= 1.0f;
            inhabitantsChange = true;
        }
        while (growthProgress < -1)
        {
            Inhabitants--;
            growthProgress += 1.0f;
            inhabitantsChange = true;
        }

        if (inhabitantsChange)
        {
            InhabitantChangeListeners.Invoke();
        }
    }

    // what fraction of the people want to pump their own water
    float GetFractionOfProductionUsed()
    {
        float priceDecicionGap = WaterPriceZeroBuy - WaterPriceAllBuy;
        float priceAboveBuyAll = WorldScript.WaterPricePerLiter - WaterPriceAllBuy;
        float rawFraction = priceDecicionGap / priceAboveBuyAll;

        // if this city suffers from drought, it tries to pump more
        rawFraction *= (WaterShortageMaxOwnProductionPoint - draughtFraction);

        return Mathf.Clamp(rawFraction, 0, 1);
    }
}
