using System.Text.RegularExpressions;
using zadanie1.Exceptions;

namespace zadanie1.Models
{
    public class BaseContainer
    {
        private string _serialNumber;
        public double PayloadMass { get; set; }
        public int Height { get; set; }
        public int SelfWeight { get; set; }
        public int Depth { get; set; }
        public required string SerialNumber 
        { 
            get => _serialNumber; 
            set {
                if (Regex.IsMatch(value, @"^KON-[A-Z]-\d+$"))
                {
                    _serialNumber = value;
                }
                else
                {
                    throw new ArgumentException("Serial number must match the format KON-{letter}-{number}");
                }
            } 
        }
        public double MaxPayloadMass { get; set; }

        public virtual void LoadCargo(double mass)
        {
            if (MaxPayloadMass <= 0)
            {
                throw new ArgumentException("Mass to load must be greater than zero.");
            }

            double newPayload = PayloadMass + mass;
            if (newPayload > MaxPayloadMass)
            {
                throw new OverfillException($"Cannot load {mass} kg. It exceeds maximum payload of {MaxPayloadMass} kg.");
            }

            PayloadMass = newPayload;
        }

        public virtual void UnloadCargo(double mass)
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
