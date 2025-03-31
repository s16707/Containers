using System;
using Containers.Utilities;

namespace Containers.Models
{
    public class FridgeContainer : Container
    {
        public string ProductType { get; }
        public double Temperature { get; }

        public FridgeContainer(double maxCapacity, string productType, double temperature) : base("C", maxCapacity)
        {
            if (!ProductTemperatureData.RequiredTemperature.ContainsKey(productType))
                throw new ArgumentException($"Unknown product type: {productType}");

            if (temperature < ProductTemperatureData.RequiredTemperatures[productType])
                throw new ArgumentException($"Temperature {temperature}C is too low for {productType}. Minimum required: {ProductTemperatureData.RequiredTemperatures[productType]}C");

            ProductType = productType;
            Temperature = temperature;
        }
    }
}