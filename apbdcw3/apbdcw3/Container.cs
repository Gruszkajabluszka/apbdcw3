namespace apbdcw3;

public abstract class Container
{
    private static int counter = 1;
    public string SerialNumber { get; }
    
    public int Height { get; }
    
    public int Depht { get; }
    public double Weight { get; set; } = 20;
    public double MaxLoad { get; }
    public double CurrentLoad { get; set; }

    protected Container(string type, double maxLoad)
    {
        SerialNumber = $"KON-{type}-{counter++}";
        MaxLoad = maxLoad;
        CurrentLoad = 0;
    }

    

    public virtual void Load(double weight)
    {
        if (CurrentLoad + weight + Weight > MaxLoad)
        {
            throw new OverflowException("Current load is too big");
        }

        CurrentLoad += weight;
    }
    
    public virtual void Unload()
    {
        CurrentLoad = 0;
    }

    public override string ToString() => $"Serial number: {SerialNumber}, Container weight: {Weight} Load: {CurrentLoad + Weight}/{MaxLoad} Kg";
}