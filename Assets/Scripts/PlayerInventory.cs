using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int initialWaterLiters;
    public int initialMoney;

    /** any change in the player water level notifies these listeners */
    public UnityEvent waterUpdateEvents;
    /** any change in the player money notifies these listeners */
    public UnityEvent moneyUpdateEvents;

    public float Water { get; private set; }
    public float Money { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Water = initialWaterLiters;
        Money = initialMoney;
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
        Money -= amount;
        moneyUpdateEvents.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
