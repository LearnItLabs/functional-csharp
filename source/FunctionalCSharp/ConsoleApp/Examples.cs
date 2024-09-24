using RandomLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp {
	class Examples {

		public void CreateRandomIntegers() {
			// var randomResult = Gen.Next(); // requires seed value

			var result = Gen.Next(124);
			Console.Write($"OriginalSeed: (124) ");
			Console.WriteLine($"NewSeed: ({result.NewSeed:N0}), Value: ({result.Value:N0}) ");

			Console.Write($"OriginalSeed: {result.NewSeed:N0} ");
			var newResult = Gen.Next(result.NewSeed);

			Console.WriteLine($"NewSeed: ({newResult.NewSeed:N0}), Value: ({newResult.Value:N0}) ");

			Console.WriteLine(new String('=', 60));

		}
		public void CreateRandomFromSystemClock() {
			var ticks = DateTime.Now.Ticks;
			var result = Gen.Next(ticks);
			Console.Write($"OriginalSeed: ({ticks:N0}) ");
			Console.WriteLine($"NewSeed: ({result.NewSeed:N0}), Value: ({result.Value:N0}) ");

			Console.Write($"OriginalSeed: ({result.NewSeed:N0}) ");
			var newResult = Gen.Next(result.NewSeed);

			Console.WriteLine($"NewSeed: ({newResult.NewSeed:N0}), Value: ({newResult.Value:N0}) ");

			Console.WriteLine(new String('=', 60));
		}
		public void CreateRandomIntegersInRange() {

			var result1 = Gen.Between(low: 1, high: 99, seed: DateTime.Now.Ticks);
			var result2 = Gen.Between(low: 1, high: 99, seed: result1.NewSeed);
			var result3 = Gen.Between(low: 1, high: 99, seed: result2.NewSeed);

			Console.WriteLine($"{result1.Value},{result2.Value},{result3.Value}");
			Console.WriteLine(new String('=', 60));
		}
		public void CreateRandomOtherTypes() {
			var bResult = Gen.Next(DateTime.Now.Ticks).AsBool();
			var dResult = Gen.Next(DateTime.Now.Ticks).AsDouble();
			var cResult = Gen.Next(DateTime.Now.Ticks).AsChar();
		}
		public void CreateARandomList() {
			// Don't use for statement
			for (int i = 0; i < 10; i++)
			{
				// call Gen.Next (seed)
			}

			// better approach is to use an expression (LINQ?)


			var list = Gen.CreateRandomSet(seed: 123, count: 10,
																								 low: -125, high: 120).ToList();
		}
		public void OrderListRandomly() {
			//var numbers = new List<int>(Enumerable.Range(10, 30));
			//var results = Gen.ReorderSet<int>(seed: DateTime.Now.Ticks, currentSet: numbers);

			var robot1 = new Robot("Alpha", "Crimson");
			var robot2 = new Robot("Bravo", "Indigo");
			var robot3 = new Robot("Charlie", "Crimson");
			var robot4 = new Robot("Delta", "Indigo");
			var robot5 = new Robot("Echo", "Crimson");
			var robot6 = new Robot("Foxtrot", "Indigo");
			List<Robot> robots = [robot1, robot2, robot3, robot4, robot5, robot6];

			var robotsOrderedBy = Gen.ReorderSet<Robot>(seed: DateTime.Now.Ticks, currentSet: robots);
		}
	}
	public class Robot {
		public string Name { get; }
		public string TeamName { get; }
		public Robot(string name, string teamName) {
			Name = name;
			TeamName = teamName;
		}
	}
}
