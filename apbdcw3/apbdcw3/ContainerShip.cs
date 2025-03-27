namespace apbdcw3;

public class ContainerShip
{
    public string Name { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    public List<Container> ContainersList { get; }

    private List<Container> _container = new();

    public ContainerShip(string name, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        ContainersList = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (_container.Count >= MaxContainers || _container.Sum(c => c.CurrentLoad) + container.CurrentLoad > MaxWeight)
        {
            throw new Exception("Cannot load more containers!");
        }

        _container.Add(container);
    }

    public void LoadContainers(List<Container>? containers)
    {
        foreach (var cont in ContainersList)
        {
            if (_container.Count >= MaxContainers || _container.Sum(c => c.CurrentLoad) + cont.CurrentLoad > MaxWeight)
            {
                throw new Exception("Cannot load more containers!");
            }

            _container.Add(cont);
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        _container.RemoveAll(c => c.SerialNumber == serialNumber);
    }

    public void SwapContainer(ContainerShip otherShip, string serialNumber1, string serialNumber2)
    {
        var container1 = _container.FirstOrDefault(c => c.SerialNumber == serialNumber1);
        var container2 = otherShip._container.FirstOrDefault(c => c.SerialNumber == serialNumber2);

        if (container1 == null || container2 == null)
        {
            throw new Exception("Both containers not found on their respective ships!");
        }
        else
        {
            _container.Remove(container1);
            otherShip._container.Remove(container2);

            _container.Add(container2);
            otherShip._container.Add(container1);
        }
    }


    public void UnloadContainer(string serialNumber)
    {
        foreach (var cont in _container)
        {
            if (cont.SerialNumber == serialNumber)
            {
                cont.Unload();
            }
        }
    }

    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = _container.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            RemoveContainer(serialNumber);
            targetShip.LoadContainer(container);
        }
    }

    public void PrintContainerInfo(string serialNumber)
    {
        foreach (var cont in _container)
        {
            if (cont.SerialNumber == serialNumber)
            {
                Console.WriteLine(cont.ToString());
            }
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine(
            $"Ship: {Name}, Containers: {_container.Count}/{MaxContainers}, Weight: {_container.Sum(c => c.CurrentLoad + c.Weight)}/{MaxWeight} Kg");
        _container.ForEach(c => Console.WriteLine(c));
    }
}