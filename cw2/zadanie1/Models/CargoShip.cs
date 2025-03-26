using zadanie1.Exceptions;

namespace zadanie1.Models
{
    public class CargoShip
    {
        public List<BaseContainer> Containers { get; set; }
        public int Vmax { get; set; }
        public int MaxAmountOfContainers { get; set; }
        public double MaxWeightOfContainers {  get; set; }

        public void LoadContainer(BaseContainer container)
        {
            if(Containers.Sum(c => c.PayloadMass) + container.PayloadMass > MaxWeightOfContainers
                || Containers.Count() > MaxAmountOfContainers)
            {
                throw new OverfillException($"Cannot add another container. Ship will be overloaded.");
            }

            Containers.Add(container);
        }

        public void UnloadContainer(BaseContainer container)
        {
            if (Containers.Contains(container))
            {
                Containers.Remove(container);
            }
            else
            {
                Console.WriteLine("Given container does not exist on this ship.");
            }
        }

        public void ReplaceContainers(string serialNumberToReplace, BaseContainer newContainer)
        {
            int index = Containers.FindIndex(c => c.SerialNumber == serialNumberToReplace);

            if(index != -1)
            {
                Containers[index] = newContainer;
            }
            else
            {
                Console.WriteLine($"Could not find a container with given serial number: {serialNumberToReplace}");
            }
        }

        public static void TransferContainer(CargoShip sourceShip, CargoShip targetShip, string serialNumber)
        {
            var container = sourceShip.Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);

            if (container == null)
            {
                Console.WriteLine($"Container with given serial number: {serialNumber} does not exist on source ship.");
                return;
            }
            
            bool hasSpace = targetShip.Containers.Count < targetShip.MaxAmountOfContainers;
            double currentWeight = targetShip.Containers.Sum(c => c.PayloadMass);
            bool hasWeightCapacity = (currentWeight + container.PayloadMass) <= targetShip.MaxAmountOfContainers;

            if(!hasSpace || !hasWeightCapacity)
            {
                Console.WriteLine("Not enough space or lift capacity to transfer container.");
                return;
            }

            sourceShip.Containers.Remove(container);
            targetShip.Containers.Add(container);

            Console.WriteLine($"Container {serialNumber} has been transferred.");
        }
    }
}
