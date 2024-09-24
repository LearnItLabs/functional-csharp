using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLib {
	public class RandomResult<T> {
		public T Value { get; }
		public int Seed { get; }
		public RandomResult(T value, int seed) {
			Value = value;
			Seed = seed;
		}
	}
}
