using zadanie1.Enums;

namespace zadanie1.Models
{
    public class ReeferContainer : BaseContainer
    {
        public RefrigeratedProductType ProductType { get; set; }
        public double Temperature {  get; set; }

        public ReeferContainer(RefrigeratedProductType productType, double temperature) 
        {
            ProductType = productType;
            Temperature = temperature;
            CheckIfTemperatureIsCorrect();
        }

        public Dictionary<RefrigeratedProductType, double> ProductTypeToTemperature = new Dictionary<RefrigeratedProductType, double>
        {
            { RefrigeratedProductType.BANANAS, 13.3 },
            { RefrigeratedProductType.CHOCOLATE, 18 },
            { RefrigeratedProductType.FISH, 2 },
            { RefrigeratedProductType.MEAT, -15 },
            { RefrigeratedProductType.ICE_CREAM, -18 },
            { RefrigeratedProductType.FROZEN_PIZZA, -30 },
            { RefrigeratedProductType.CHEESE, 7.2 },
            { RefrigeratedProductType.SAUSAGES, 5 },
            { RefrigeratedProductType.BUTTER, 20.5 },
            { RefrigeratedProductType.EGGS, 19 }
        };

        private void CheckIfTemperatureIsCorrect()
        {
            if (ProductTypeToTemperature.TryGetValue(ProductType, out double requiredTemperature))
            {
                if(Temperature < requiredTemperature)
                {
                    throw new InvalidOperationException($"Temperature for product: {ProductType} is too low." +
                        $"Required: {requiredTemperature} degrees Celsius, current: {Temperature} degrees Celcius.");
                }
            }
            else 
            {
                throw new KeyNotFoundException($"Could not find temperature requirements for product: {ProductType}");
            }
        }
    }
}
