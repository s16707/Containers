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
    }
}