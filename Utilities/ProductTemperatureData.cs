using System;

namespace Containers.Utilities
{ 
	public static class ProductTemperatureData
	{
		public static readonly Dictionary<string, double> RequiredTemperatures = new()
		{
			{ "Bananas", 13.3 },
			{ "Chocolate", 18 },
			{ "Fish", 2 },
			{ "Meat", -15 },
			{ "Ice cream", -18 },
			{ "Frozen pizza", -30 },
			{ "Cheese", 7.2 },
			{ "Sausages", 5 },
			{ "Butter", 20.5 },
			{ "Eggs", 19 }

		};

	}
}
