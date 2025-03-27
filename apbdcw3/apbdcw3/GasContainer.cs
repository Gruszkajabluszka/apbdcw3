namespace apbdcw3;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(double maxLoad, double pressure) : base("G", maxLoad)
    {
        Pressure = pressure;
    }

    public override void Unload( )
    {
        CurrentLoad *= 0.05;
    }
    

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {SerialNumber}: {message}");
    }
}