using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLib {
	public static class RandomExtensions {

		public static RandomResult<bool> AsBool(this RandomResult<int> result) {
			return new RandomResult<bool>(result.Value % 2 == 0, result.NewSeed);
		}

		public static RandomResult<Char> AsChar(this RandomResult<int> result) {
			Char charConvert = (char)(result.Value % (char.MaxValue + 1));

			return new RandomResult<char>(charConvert, result.NewSeed);
		}
		public static RandomResult<double> AsDouble(this RandomResult<int> result) {
			// Normalize the integer value to be between 0 and 1
			double doubleConvert = (double)result.Value / int.MaxValue;

			return new RandomResult<double>(doubleConvert, result.NewSeed); ;
		}
	}
}
