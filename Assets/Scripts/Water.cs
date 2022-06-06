public class Water
{
    public Water(int milliliters)
    {
        _numMilliLiter = milliliters;
    }

    public Water(float liters)
    {
        _numMilliLiter = (int)(liters / 1000);
    }

    private int _numMilliLiter = 0;

    public float AsValue() => _numMilliLiter / 1000.0f;

    public void Add(Water Water) => _numMilliLiter += Water._numMilliLiter;

    public void Remove(Water Water) => _numMilliLiter += Water._numMilliLiter;
}
