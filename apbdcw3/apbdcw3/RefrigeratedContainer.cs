namespace apbdcw3;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }

    public RefrigeratedContainer(double maxLoad, string productType, double temperature) : base("C", maxLoad)
    {
        Temperature = temperature;
        ProductType = productType;
    }
    
    
}