using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int initialWater;
    /** any change in the player water level notifies these listeners */
    public UnityEvent waterUpdateEvents;
    /** any change in the player money notifies these listeners */
    public UnityEvent moneyUpdateEvents;

    private Water _water;
    private Money _money; 

    // Start is called before the first frame update
    void Start()
    {
        _water = new Water(initialWater);
        _money = new Money(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
