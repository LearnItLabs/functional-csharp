using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp {
	class Examples {

		// how C# represents functions
		// Methods
		// Delegates
		// Lambda expressions

		// of these, Delegates and Lambda expressions 
		// are the most useful for functional programming


		public void LinqExamples() {
			var numbers = Enumerable.Range(1, 120);

			var last = numbers.Last();
			var LastWithLambda = numbers.Last(n => n < 40);

			// The Where operator filters the sequence,
			// it expects a predicate that determines  
			// the filter criteria.
			var oddNumbers = numbers.Where(n => n % 2 != 0);



			// TakeWhile: Returns elements from a sequence 
			// as long as a specified condition is true, 
			// and then skips the remaining elements.
			var moreNumbers = new List<int> { 21, 32, 43, 54, 65, 201, 301, 401, 76, 87, 98 };

			var subset = moreNumbers.TakeWhile(n => n < 100);

			// tranform the data with Select

			var doubles = numbers.Select(n => (double) n + (double) n/10);

		}


		public void FilterExample() {
			var numbers = Enumerable.Range(1, 120);


			var divisibleByFive = numbers.MyWhere(x => x % 5 == 0);
			var divisibleBySeven = numbers.MyWhere(x => x % 7 == 0);
		}
		public void TransformExample() {
			var numbers = Enumerable.Range(1, 120);
			var PowersOfThree = numbers.MyTransform(x => x * x * x);
		}

		public void FunctionReturn() {
			var numbers = Enumerable.Range(1, 120);

			// var PowersOfThree = numbers.MyTransform(x => x * x * x);

			var Added = numbers.MyTransform(Factory.AddTo(3));
			var maxNumbers = numbers.MyTransform(Factory.GetMax(20));
		}
	

	}
	
}
