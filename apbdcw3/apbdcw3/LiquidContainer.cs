namespace apbdcw3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(double maxLoad, bool isHazardous) : base("L", maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double limit = IsHazardous ? MaxLoad * 0.5 + Weight : MaxLoad * 0.9 + Weight;
        if (weight > limit)
        {
            NotifyHazard("Loading exceeded safety limits!");
        }

        base.Load(weight);
    }
    

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {SerialNumber}: {message}");
    }
}