using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ConsoleApp {
	internal class Examples {
		public void JoinExample() {
			// SelectMany is also useful for joining similar lists

			var setA = Enumerable.Range(2, 3);
			var setB = Enumerable.Range(5, 3);

			var basicSelect = setA.Select(a => setB.Select(b => $"A {a}, B:{b}"));

			var basicJoin = setA.SelectMany(a => setB.Select(b => $"A:{a} B:{b}"));


			var resultsA = basicSelect.ToList();
			var resultsB = basicJoin.ToList();
		}


		public void FlattenListExample() {
			// Functional bind (Haskell) or flatMap (Scala)
			// Known as flattening in C#
			// Implemented using LINQ SelectMany or ContinueWith

			// Flattens a multi-dimensional set into a single set

			// or another way to say
			// SelectMany selects values from a nested collection

			var brandA = new Brand(name: "Fancy-Shoes",
														 colors: new List<string> { "Red", "Orange" });


			var brandB = new Brand(name: "Lux-Cars",
														 colors: new List<string> { "Gold", "Silver" });
			var brandC = new Brand(name: "Wow-Electronics",
														colors: new List<string> { "Blue", "Purple" });
			var brands = ImmutableList<Brand>.Empty;
			brands = brands.Add(brandA);
			brands = brands.Add(brandB);
			brands = brands.Add(brandC);


			// this does not produce the results we want
			var flattenedA = brands.Select(x => x.Colors).ToImmutableList();
			var flattenedB = brands.SelectMany(x => x.Colors).ToImmutableList();
		}
	}

	public class Brand {
		public string Name { get; }
		public List<string> Colors { get; }
		public Brand(string name, List<string> colors) {
			Name = name;
			Colors = colors;

		}
	}
}





