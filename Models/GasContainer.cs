using System;
using Containers.Interfaces;

namespace Containers.Models
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; private set; }

        public GasContainer(double maxCapacity, double pressure) : base { "G", maxCapacity)
         {
                Pressure = pressure;
         }

            public override void Unload()
        {
            CurrentLoad *= 0.05;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"HAZARD NOTIFICATION: {message}");
        }
    }
}
