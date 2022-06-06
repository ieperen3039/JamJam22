public class Money
{
    public Money(int numCents)
    {
        _numCents = numCents;
    }

    public Money(float value)
    {
        _numCents = (int)(value / 100);
    }

    private int _numCents = 0;

    public float AsValue() => _numCents / 100.0f;

    public void Add(Money money) => _numCents += money._numCents;

    public void Remove(Money money) => _numCents += money._numCents;
}
