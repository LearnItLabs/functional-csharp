using RandomLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp {
	class Examples {

		public void CreateRandomIntegers() {
			// var randomResult = Gen.Next(); // requires seed value

			var result = Gen.Next(124);
			Console.Write($"OriginalSeed: 124 ");
			Console.WriteLine($"NewSeed: {result.Seed}, Value: {result.Value} ");

			Console.Write($"OriginalSeed: {result.Seed} ");
			var newResult = Gen.Next(result.Seed);

			Console.WriteLine($"Seed: {newResult.Seed}, Value: {newResult.Value} ");

			Console.WriteLine(new String('=', 60));

		}
		public void CreateRandomFromSystemClock() {
			var ticks = DateTime.Now.Ticks;
			var result = Gen.Next(ticks);
			Console.Write($"OriginalSeed:{ticks} ");
			Console.WriteLine($"NewSeed: {result.Seed}, Value: {result.Value} ");

			Console.Write($"OriginalSeed: {result.Seed} ");
			var newResult = Gen.Next(result.Seed);

			Console.WriteLine($"Seed: {newResult.Seed}, Value: {newResult.Value} ");

			Console.WriteLine(new String('=', 60));
		}
		public void CreateRandomIntegersInRange() {

			var result1 = Gen.Between(low: 1, high: 99, seed: DateTime.Now.Ticks);
			var result2 = Gen.Between(low: 1, high: 99, seed: result1.Seed);
			var result3 = Gen.Between(low: 1, high: 99, seed: result2.Seed);

			Console.WriteLine($"{result1.Value},{result2.Value},{result3.Value}");

			Console.WriteLine(new String('=', 60));
		}

		public void CreateRandomOtherTypes() {
			var bResult = Gen.Next(DateTime.Now.Ticks).AsBool();
			var dResult = Gen.Next(DateTime.Now.Ticks).AsDouble();
			var cResult = Gen.Next(DateTime.Now.Ticks).AsChar();
		}


		public void CreateARandomList() {

			var list = Gen.CreateRandomSet(seed: 123, count: 10,
																								 low: -125, high: 120).ToList();


		}

		public void OrderListRandomly() {
			var numbers = Enumerable.Range(10,30);

			var results = Gen.ReorderSet(seed: 423, currentSet: numbers);
		}
	}
}
