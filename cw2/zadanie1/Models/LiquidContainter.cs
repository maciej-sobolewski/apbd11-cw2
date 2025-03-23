using zadanie1.Interfaces;

namespace zadanie1.Models
{
    public class LiquidContainter : BaseContainer, IHazardNotifier
    {
        public bool IsPayloadHazardous { get; set; }
        public void CheckHazard()
        {
            double loadRatio = (double)PayloadMass / MaxPayloadMass * 100;

            if (loadRatio > 50 && IsPayloadHazardous) 
            {
                Console.WriteLine("CRITICAL HAZARD: Load exceeds 50% of maximum capacity for hazardous cargo!");
            }
            else if (loadRatio > 90)
            {
                Console.WriteLine("WARNING: Load exceeds 90% for non-hazardous cargo.");
            }
        }

        public string Notify()
        {
            throw new NotImplementedException();
        }

        public override void LoadCargo(int mass)
        {
            base.LoadCargo(mass);
            CheckHazard();
        }

        public override void UnloadCargo(int mass)
        {
            base.UnloadCargo(mass);
            CheckHazard();
        }
    }
}
