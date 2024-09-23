using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp {
	internal class Examples {
		public void FlattenAsProjection() {
			// SelectMany is also useful for creating
			// Cartesian products from two sequences

			ImmutableList<int> odds = [3, 5, 7];
			ImmutableList<int> evens = [12, 14, 16];

			// Concat method works with two flat sequences, joining them end-to-end.
			var basicConcat = odds.Concat(evens);


			var basicCartesian =
				odds.SelectMany((int x) => evens, (int a, int b) => $"A:{a} B:{b}");
			#region SelectMany Explained
			// Here’s what each part does:

			// (int x) => evens: This lambda expression takes each
			// element x from the odds list and maps it to the entire evens list.
			// Essentially, for each x in odds, it produces the entire evens list.

			// (int a, int b) => $"A:{a} B:{b}":
			// This lambda expression takes two parameters, a and b.
			// Here, a represents an element from the odds list,
			// and b represents an element from the evens list.
			// It then creates a string in the format "A:{a} B:{b}".
			#endregion


			var concatResult = basicConcat.ToImmutableList();
			var cartesianResult = basicCartesian.ToImmutableList();

		}

		public void FlattenListExample() {
			// Functional bind (Haskell) or flatMap (Scala)
			// Known as flattening in C#
			// Implemented using LINQ SelectMany or ContinueWith

			// Flattens a multi-dimensional set into a single set

			// or another way to say
			// SelectMany selects values from a nested collection

			var brandA = new Brand(name: "Fancy-Shoes",
														 colors:  ["Red", "Orange"] ,
														 socials: ["TikTok", "Instagram"]);


			var brandB = new Brand(name: "Lux-Cars",
														 colors: [ "Gold", "Silver" ],
														 socials: ["Facebook", "Instagram"]);
			var brandC = new Brand(name: "Wow-Electronics",
														colors: [ "Blue", "Purple"],
														 socials: ["Wired", "Wirecutter"]);
		
														
			var brands = ImmutableList<Brand>.Empty;
			brands = brands.Add(brandA);
			brands = brands.Add(brandB);
			brands = brands.Add(brandC);


			// this does not produce the results we want
			var notFlattened = brands.Select(x => x.Colors).ToImmutableList();

			// flat sequence of colors
			var flattenedColors = brands.SelectMany(x => x.Colors).ToImmutableList();
			// flat sequence of socials
			var flattenedSocials = brands.SelectMany(x => x.Socials).ToImmutableList(); 
		}
	}

	public class Brand {
		public string Name { get; }
		public List<string> Colors { get; }
		public List<string> Socials { get; }
		public Brand(string name, List<string> colors,List<string> socials) {
			Name = name;
			Colors = colors;
			Socials = socials;

		}
}
}





