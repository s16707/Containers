using System;
using Containers.Models;

namespace Containers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var ship = new CargoShip("Ocean Carrier", 50000, 100, 20);
                var container1 = new LiquidContainer(10000, true);
                var container2 = new GasContainer(8000, 10);
                var container3 = new FridgeContainer(12000, "Bananas", 13.3);

                container1.Load(4000);
                container2.Load(5000);
                container3.Load(10000);

                ship.AddContainer(container1);
                ship.AddContainer(container2);
                ship.AddContainer(container3);

                Console.WriteLine(ship);

                container2.Unload();
                ship.RemoveContainer(container1.SerialNumber);

                Console.WriteLine(ship);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
