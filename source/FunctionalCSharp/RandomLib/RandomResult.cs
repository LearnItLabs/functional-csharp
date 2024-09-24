using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLib {
	public class RandomResult<T> {
		public T Value { get; }
		public int NewSeed { get; } // 0 to 2,147,483,647 
		public RandomResult(T value, int newSeed) {
			Value = value;
			NewSeed = newSeed;
		}
	}
}
