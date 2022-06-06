using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private List<WaterSource> WaterSources;
    public float WaterPricePerLiter;

    public PlayerInventory PlayerInventory;

    public void AddWaterSource(WaterSource waterSource)
    {
        WaterSources.Add(waterSource);
    }
    public IEnumerator<WaterSource> GetWaterSources() => WaterSources.GetEnumerator();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float BuyWater(float litersRequested)
    {
        float available = PlayerInventory.Water;
        float litersProvided = Mathf.Min(litersRequested, available);

        PlayerInventory.RemoveWater(litersProvided);
        PlayerInventory.AddMoney(litersProvided * WaterPricePerLiter);
        return litersProvided;
    }
}
