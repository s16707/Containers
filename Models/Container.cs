using System;
using Containers.Exceptions;

namespace Containers.Models
{
    public abstract class Container
    {
        private static int _idCounter = 1;
        public string SerialNumber { get; }
        public double MaxCapacity { get; }
        public double CurrentLoad { get; private set; }

        protected Container(string type, double maxCapacity)
        {
            SerialNumber = $"KON-{type}-{_idCounter++}";
            MaxCapacity = maxCapacity;
        }

        public virtual void Load(double weight)
        {
            if (CurrentLoad + weight > MaxCapacity)
                throw new OverfillException($"Cannot load {weight}kg. Exceeds max capacity of {MaxCapacity}kg.");

            CurrentLoad += weight;
        }

        public virtual void Unload()
        {
            CurrentLoad = 0;
        }

        public override string ToString()
        {
            return $"SerialNumber: {SerialNumber}, MaxCapacity: {MaxCapacity}kg, CurrentLoad: {CurrentLoad}kg";
        }
    }
}