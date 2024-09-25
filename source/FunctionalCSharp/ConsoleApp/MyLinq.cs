using System;
using System.Collections.Generic;

namespace ConsoleApp {

	public static class MyLinq {
		// use delegates as function arguments

		public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> items,
																						Predicate<T> predicate) {
			// execute this code
			// for every item in the enumerable
			foreach (T item in items){
				if (predicate(item)) {
					yield return item;
				}
			}
		}

		public static IEnumerable<T1> MyTransform<T1>(this IEnumerable<T1> items,
																									Func<T1, T1> transformer) {
			// execute this code
			// for every item in the enumerable
			foreach (T1 item in items) {
				yield return transformer(item);
			}
		}

	
	}
	public static class Factory {
		//  Function factory, returns a function
		public static Func<int, int> AddTo(int n) => i => i + n;
		public static Func<int, int> GetMax(int n) => i => Math.Max(i, n);

	}
}