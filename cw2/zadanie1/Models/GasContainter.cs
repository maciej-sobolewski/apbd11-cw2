using zadanie1.Interfaces;

namespace zadanie1.Models
{
    public class GasContainter : BaseContainer, IHazardNotifier
    {
        public int Pressure { get; set; }
        public void CheckHazard()
        {
            Console.WriteLine($"CRITICAL HAZARD/containter {SerialNumber}: Load exceeds 50% of maximum capacity for hazardous cargo!"); //???
        }

        public override void LoadCargo(double mass)
        {
            base.LoadCargo(mass);
            CheckHazard();
        }

        public override void UnloadCargo(double mass)
        {
            mass = 0.95 * mass;

            if (mass <= 0)
            {
                throw new ArgumentException("Mass to unload must be greater than zero.");
            }

            if (mass > PayloadMass)
            {
                throw new ArgumentException("Cannot unload more cargo than is currently loaded.");
            }

            PayloadMass -= mass;

            CheckHazard();
        }
    }
}
