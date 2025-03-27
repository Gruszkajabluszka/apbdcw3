using System;
using System.Collections.Generic;
using System.Linq;
using apbdcw3;


public  class Program
{
    static void Main()
    {
        var ship = new ContainerShip("Neptune", 400, 5000);
        var ship2 = new ContainerShip("Pluton", 70, 10000);
        var bananaContainer = new RefrigeratedContainer(1000, "Bananas", 10);
        var gasContainer = new GasContainer(500, 5);
        var fuelContainer = new LiquidContainer(1000, true);

        var iceCreamContainer = new RefrigeratedContainer(1000, "Ice Cream", -10);
        var helContainer = new GasContainer(1000, 10);
        var toxicWasteContainer = new LiquidContainer(1000, true);
        bananaContainer.Load(700);
        gasContainer.Load(300);
        fuelContainer.Load(300);
        iceCreamContainer.Load(300);
        helContainer.Load(800);
        toxicWasteContainer.Load(300);


        ship.LoadContainer(bananaContainer);
        ship.LoadContainer(gasContainer);
        ship.LoadContainer(fuelContainer);
        
        ship2.ContainersList.Add(iceCreamContainer);
        ship2.ContainersList.Add(helContainer);
        ship2.ContainersList.Add(toxicWasteContainer);
        
        ship2.LoadContainers(ship2.ContainersList);
        
        ship.UnloadContainer(fuelContainer.SerialNumber);
        
        ship.RemoveContainer(bananaContainer.SerialNumber);
        ship2.RemoveContainer(helContainer.SerialNumber);
        
        ship.SwapContainer(ship2, gasContainer.SerialNumber, iceCreamContainer.SerialNumber);
        
        ship.TransferContainer(ship2,iceCreamContainer.SerialNumber);
        
        

        ship.PrintShipInfo();
        Console.WriteLine("\n");
        ship2.PrintShipInfo();
        Console.WriteLine("\n");
        ship2.PrintContainerInfo(iceCreamContainer.SerialNumber);
        
        var milkContainer = new LiquidContainer(1000, false);
        milkContainer.Load(300);
        milkContainer.Weight=50;
        ship.LoadContainer(milkContainer);
        ship.PrintContainerInfo(milkContainer.SerialNumber);
        
        
        
    }
}