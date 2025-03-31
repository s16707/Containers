using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerManagement.Models
{
    public class CargoShip
    {
        public string Name { get; }
        public double MaxWeight { get; }
        public int MaxContainers { get; }
        public double MaxSpeed { get; }
        private readonly List<Container> _containers;

        public CargoShip(string name, double maxWeight, int maxContainers, double maxSpeed)
        {
            Name = name;
            MaxWeight = maxWeight;
            MaxContainers = maxContainers;
            MaxSpeed = maxSpeed;
            _containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
            if (_containers.Count >= MaxContainers)
                throw new InvalidOperationException("Ship cannot hold more containers.");

            if (_containers.Sum(c => c.MaxCapacity) + container.MaxCapacity > MaxWeight * 1000)
                throw new InvalidOperationException("Adding this container exceeds the ship's weight limit.");

            _containers.Add(container);
        }

        public void RemoveContainer(string serialNumber)
        {
            var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
                _containers.Remove(container);
        }

        public void TransferContainer(string serialNumber, CargoShip targetShip)
        {
            var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container == null)
                throw new InvalidOperationException("Container not found on this ship.");

            RemoveContainer(serialNumber);
            targetShip.AddContainer(container);
        }

        public override string ToString()
        {
            return $"Ship Name: {Name}, MaxWeight: {MaxWeight}t, MaxContainers: {MaxContainers}, MaxSpeed: {MaxSpeed} knots\nContainers: {string.Join(", ", _containers.Select(c => c.SerialNumber))}";
        }
    }
}
