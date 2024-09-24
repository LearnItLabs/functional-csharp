namespace RandomLib {

	public class Gen {

		private const int Mask = 0x7fffffff;
		public static RandomResult<int> Next(int seed) {
			
			seed ^= seed >> 13;
			seed ^= seed << 18;
			int result = seed & Mask;

			return new RandomResult<int>(result, result);
		}

		public static RandomResult<int> Next(long seed) {

			int intSeed = (int)(seed % int.MaxValue);
			intSeed ^= intSeed >> 13;
			intSeed ^= intSeed << 18;
			int result = intSeed & Mask;

			return new RandomResult<int>(result, result);
		}

		public static RandomResult<int> Between(int low, int high, long seed) {
			int intSeed = (int)(seed % int.MaxValue);
			// Generate the next integer using the seed
			var nextInt = Next(intSeed);

			// Map the result to the specified range [low, high)
			int value = low + nextInt.Value % (high - low);
			return new RandomResult<int>(value, nextInt.Seed);
		}

		//public static IEnumerable<int> CreateRandomSet(int seed, int count) {
		//	return Enumerable.Range(0, count)
		//					 .Select(_ =>
		//					 {
		//						 var result = Next(seed);
		//						 seed = result.Seed; // Update the seed for the next iteration
		//						 return result.Value;
		//					 })
		//					 ;
		//}

		public static IEnumerable<int> CreateRandomSet(int seed, 
																									 int count, 
																									 int low = 0, 
																									 int high = int.MaxValue) {
			return Enumerable.Range(0, count)
							 .Select(_ =>
							 {
								 var result = Next(seed);
								 seed = result.Seed; // Update the seed for the next iteration (side-effect)
								 return Between(low, high, seed).Value;
							 })
							 ;
		}
		public static IEnumerable<int> ReorderSet(int seed,
																							IEnumerable<int> currentSet) {
			return Enumerable.Range(0, currentSet.Count())
				.OrderBy(_=> {
					var result = Next(seed);
					seed = result.Seed; // Update the seed for the next iteration
					return Next(seed).Value;
				})			 
;
		}

	}


}
