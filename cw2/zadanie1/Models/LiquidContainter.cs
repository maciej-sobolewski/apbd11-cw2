using zadanie1.Enums;
using zadanie1.Interfaces;

namespace zadanie1.Models
{
    public class LiquidContainter : BaseContainer, IHazardNotifier
    {
        public LiquidProductType ProductType { get; set; }
        public bool IsPayloadHazardous { get; set; }

        public Dictionary<LiquidProductType, bool> ProductTypeToIsHazardous = new Dictionary<LiquidProductType, bool> 
        {
            { LiquidProductType.GASOLINE, true },
            { LiquidProductType.MILK, false }
        };

        public LiquidContainter(LiquidProductType productType)
        {
            ProductType = productType;
            IsHazardous();
        }

        public void CheckHazard()
        {
            double loadRatio = PayloadMass / MaxPayloadMass * 100;

            if (loadRatio > 50 && IsPayloadHazardous) 
            {
                Console.WriteLine($"CRITICAL HAZARD/containter {SerialNumber}: Load exceeds 50% of maximum capacity for hazardous cargo!");
            }
            else if (loadRatio > 90)
            {
                Console.WriteLine($"WARNING/containter {SerialNumber}: Load exceeds 90% for non-hazardous cargo.");
            }
        }

        private void IsHazardous()
        {
            if(ProductTypeToIsHazardous.ContainsKey(ProductType))
                IsPayloadHazardous = ProductTypeToIsHazardous[ProductType];
        }

        public override void LoadCargo(double mass)
        {
            base.LoadCargo(mass);
            CheckHazard();
        }

        public override void UnloadCargo(double mass)
        {
            base.UnloadCargo(mass);
            CheckHazard();
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", \n Stored cargo: {ProductType}";
        }
    }
}
