using System;
using zadanie1.Models;

class Program
{
    static void Main(string[] args)
    {
        //just for test
        var liquidContainer = new LiquidContainter(zadanie1.Enums.LiquidProductType.MILK) 
        {
            Height = 3,
            SelfWeight = 5,
            Depth = 20,
            SerialNumber = "KON-A-1",
            MaxPayloadMass = 100
        };

        var reeferContainer = new ReeferContainer(zadanie1.Enums.RefrigeratedProductType.BANANAS, 13.4) 
        {
            Height = 3,
            SelfWeight = 5,
            Depth = 20,
            SerialNumber = "KON-B-1",
            MaxPayloadMass = 100
        };

        liquidContainer.LoadCargo(30);
        reeferContainer.LoadCargo(95);
        liquidContainer.CheckHazard();

        var ship1 = new CargoShip
        {
            Containers = new List<BaseContainer>(),
            Vmax = 50,
            MaxAmountOfContainers = 100,
            MaxWeightOfContainers = 10000
        };

        var containers = new List<BaseContainer>();
        containers.Add(liquidContainer);
        containers.Add(reeferContainer);

        foreach (BaseContainer container in containers)
        {
            ship1.LoadContainer(container);
        }

        ship1.UnloadContainer(liquidContainer);

        var ship2 = new CargoShip
        {
            Containers = new List<BaseContainer>(),
            Vmax = 75,
            MaxAmountOfContainers = 500,
            MaxWeightOfContainers = 100000
        };

        ship1.ReplaceContainers("KON-B-1", liquidContainer);

        CargoShip.TransferContainer(ship1, ship2, "KON-A-1");
    }
}