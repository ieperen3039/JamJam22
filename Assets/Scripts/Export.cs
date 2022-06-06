using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Export : MonoBehaviour
{
    public float MaxWaterSellPrice = 1.0f;
    public float SaturationPerLiter = 0.001f;
    public float SaturationFalloff = 0.001f;

    private float _marketSaturation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float falloff = SaturationFalloff;
        _marketSaturation *= (1 - falloff);
    }

    // returns the amount of money gained
    public float SellWater(float litersToSell)
    {
        float saturationSq = _marketSaturation * _marketSaturation;
        float demand = (1 - saturationSq);
        float waterSellPrice = demand * MaxWaterSellPrice;

        _marketSaturation += litersToSell * SaturationPerLiter;

        // return price
        return litersToSell * waterSellPrice;
    }
}
