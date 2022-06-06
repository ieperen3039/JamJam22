using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int initialWaterLiters;
    public int initialMoney;
    public int initialReputation;

    /** any change in the player water level notifies these listeners */
    public UnityEvent waterUpdateEvents;
    /** any change in the player money notifies these listeners */
    public UnityEvent moneyUpdateEvents;
    /** any change in the player reputation notifies these listeners */
    public UnityEvent reputationUpdateEvents;

    public float Water { get; private set; }
    public float Money { get; private set; }
    public float Reputation { get; private set; }
    public float Energy { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Water = initialWaterLiters;
        Money = initialMoney;
        Reputation = initialReputation;
    }

    public void AddWater(float amountLiters)
    {
        Water += amountLiters;
        waterUpdateEvents.Invoke();
    }

    public void PrintHello()
    {
        Debug.Log("PrintHello function was indeed called");
    }

    public void RemoveWater(float amountLiters)
    {
        if (amountLiters > Water)
        {
            throw new System.ArgumentException();
        }

        Water -= amountLiters;
        waterUpdateEvents.Invoke();
    }

    public void AddMoney(float amount)
    {
        Money += amount;
        moneyUpdateEvents.Invoke();
    }

    public void RemoveMoney(float amount)
    {
        if (amount > Money)
        {
            throw new System.ArgumentException();
        }

        Money -= amount;
        moneyUpdateEvents.Invoke();
    }

    public void AddReputation(float amount)
    {
        Reputation += amount;
        reputationUpdateEvents.Invoke();
    }

    public void RemoveReputation(float amount)
    {
        Reputation -= amount;
        reputationUpdateEvents.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
