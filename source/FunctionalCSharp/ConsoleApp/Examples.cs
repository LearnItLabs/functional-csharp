using System;
using System.Collections.Immutable;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace ConsoleApp {
	internal class Examples {
		public void AggregateExample() {
			// Function fold (or reduce)
			// Applies a function to each item in the list
			// Takes a list and returns a single result (not a list)
			// It is an accumulative function
			// For example, SUM totals the 1st and 2nd item,
			// then totals that result with the 3rd item, and so on...
			// 
			// LINQ (Aggregate, Sum, Average)
			// LINQ (Max, Min, Count)

			ImmutableList<int> setA = [5, 4, 1, 3, 9, 8, 6, 7, 2, 12, 24];
			
			// list of numbers 5 through 40 (by five)
			ImmutableList<int> setB =
				ImmutableList.CreateRange(Enumerable.Range(1, 40).Where(x => x % 5 == 0));

			// predefined aggregates
			var total = setA.Sum();
			var count = setB.Count();
			var highestNumber = setB.Max();


			// custom aggregate/accumulator
			// The Aggregate function in LINQ can take up to three arguments, which allows for more complex aggregation scenarios.

			// Seed: The initial accumulator value.
			// Func: A function that is applied to each element in the sequence, updating the accumulator.
			// Result Selector: A function applied to the final accumulator value to produce the result.

			var multipleOf = setA.Aggregate((first, second) => first * second);

			// set the initial seed (accumulator value)

			var anotherMultiple = setA.Aggregate(100, (first, second) => first * second);
		}

		public void AggregateRobots() {

			var robot1 = new Robot(name: "Robot1", batteryLevel: 60);
			var robot2 = new Robot(name: "Robot2", batteryLevel: 45);
			var robot3 = new Robot(name: "Robot3", batteryLevel: 95);
			var robot4 = new Robot(name: "Robot4", batteryLevel: 27);

			ImmutableList<Robot> robots = ImmutableList.Create(new Robot[] { robot1, robot2, robot3, robot4 });

			var lowBattery = robots.Min(x => x.BatteryLevel);

		}

	}




	public class Robot {
		public string Name { get; }
		public int BatteryLevel { get; }
		public Robot(string name, int batteryLevel) {
			Name = name;
			BatteryLevel = batteryLevel;
		}
	}
}