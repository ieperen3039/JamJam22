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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    float GenerateWater()
    {
        if ( moneyResources > moneyPerTick &&
             energyResources > energyPerTick )
        {
            moneyResources -= moneyPerTick;
            energyResources -= energyPerTick;
            return waterPerTick;
        }
        else
        {
            return 0.0f;
        }
    }
}
