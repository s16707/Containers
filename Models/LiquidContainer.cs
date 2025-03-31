using System;
using Containers.Interfaces;

namespace Containers.Models
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public bool IsHazardous { get; }

        public LiquidContainer(double maxCapacity, bool isHazardous) : base("L", maxCapacity)
        {
            IsHazardous = isHazardous;
        }

        public override void Load(double weight)
        {
            double capacityLimit = IsHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

            if (CurrentLoad + weight > capacityLimit)
                NotifyHazard($"Attempted to load {weight}kg into hazardous container {SerialNumber}. Exceeds limit.");

            base.Load(weight);
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"HAZAR NOTIFICATION: {message}");
        }
    }
}