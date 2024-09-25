using System.Collections.Immutable;

namespace RandomLib {

	public class Gen {

		private const int Mask = 0x7fffffff;
		public static RandomResult<int> Next(int seed) {
			int tempSeed = seed;
			tempSeed ^= tempSeed >> 13;
			tempSeed ^= tempSeed << 18;
			int result = tempSeed & Mask; 

			return new RandomResult<int>(result, result);
		}

		public static RandomResult<int> Next(long seed) {

			int intSeed = (int)(seed % int.MaxValue);

			return Next(intSeed);
		}

		public static RandomResult<int> Between(int low, int high, long seed) {
			int intSeed = (int)(seed % int.MaxValue);
			// Generate the next integer using the seed
			var nextInt = Next(intSeed);

			// Map the result to the specified range [low, high)
			int value = low + nextInt.Value % (high - low);
			return new RandomResult<int>(value, nextInt.NewSeed);
		}

		public static IEnumerable<int> CreateRandomSet(int seed,
																									 int count,
																									 int low = 0,
																									 int high = int.MaxValue) {
			int localSeed = seed;
			return Enumerable.Range(0, count)
							 .Select(_ =>
							 {
								 var result = Next(localSeed);
								 localSeed = result.NewSeed; // Update the seed for the next iteration (side-effect)
								 return Between(low, high, localSeed).Value;
							 })
							 ;
		}
		public static ImmutableList<T> ReorderSet<T>(long seed,
																							ImmutableList<T> currentSet) {
			int intSeed = (int)(seed % int.MaxValue);
			int localSeed = intSeed;
			return Enumerable.Range(0, currentSet.Count())
				.OrderBy(_ =>
				{
					var result = Next(localSeed);
					localSeed = result.NewSeed; // Update the seed for the next iteration
					return Next(localSeed).Value;
				}).Select(index => currentSet[index]).ToImmutableList();
			;
		}

	}


}
