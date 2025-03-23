using zadanie1.Exceptions;

namespace zadanie1.Models
{
    public class BaseContainer
    {
        public int PayloadMass { get; set; }
        public int Height { get; set; }
        public int SelfWeight { get; set; }
        public int Depth { get; set; }
        public string SerialNumber { get; set; }
        public int MaxPayloadMass { get; set; }

        public virtual void LoadCargo(int mass)
        {
            if (MaxPayloadMass <= 0)
            {
                throw new ArgumentException("Mass to load must be greater than zero.");
            }

            int newPayload = PayloadMass + mass;
            if (newPayload > MaxPayloadMass)
            {
                throw new OverfillException($"Cannot load {mass} kg. It exceeds maximum payload of {MaxPayloadMass} kg.");
            }

            PayloadMass = newPayload;
        }

        public virtual void UnloadCargo(int mass)
        {
            if (mass <= 0)
            {
                throw new ArgumentException("Mass to unload must be greater than zero.");
            }

            if(mass > PayloadMass)
            {
                throw new ArgumentException("Cannot unload more cargo than is currently loaded.");
            }

            PayloadMass -= mass;
        }
    }
}
