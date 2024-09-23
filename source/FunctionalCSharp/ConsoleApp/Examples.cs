using System;
using System.Collections.Immutable;
using System.Linq;

namespace ConsoleApp
{
	internal class Examples
	{
		public void FilterSimple()
		{
			// Functional 'filter' is implemented in LINQ as Where.
			// Returns a subset of the list based on the provided predicate function.

			var numbers = ImmutableList.CreateRange<int>(Enumerable.Range(1, 200));


			var queryA = numbers.Where(x => x < 20).Select(x => x);

			var queryB = from n in numbers
									 where n < 20 || n > 180
									 select n;

			var resultsA = queryA.ToList();
			var resultsB = queryB.ToList();
		}

		public void FilterForPrimeNumbers()
		{
			// The isPrime predicate determines if
			// a number is prime.

			Func<int, bool> isPrime = p => Enumerable.Range(2, (int)Math.Sqrt(p) - 1)
																		.All(divisor => p % divisor != 0);

			var numbers = ImmutableList.CreateRange<int>(Enumerable.Range(2, 1000_000));

			var q = numbers.Where(isPrime);

			var primes = q.ToImmutableList<int>();
		}
	}
}
