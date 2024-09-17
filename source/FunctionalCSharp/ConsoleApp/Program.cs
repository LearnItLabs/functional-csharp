using System;
namespace ConsoleApp {
	class Program {

		static void Main(string[] args) {

			var sColor = new SimpleColor(red: 10, green: 20, blue: 30);
			Console.WriteLine($"Initial hex value: {sColor.HexValue}" );

			// Setting the .HexValue  property causes a side effect.
			// It changes the Red, Green, and Blue properties.

			sColor.HexValue = "#AA77BB";
			Console.WriteLine($"Modified hex value: {sColor.HexValue}");
		}

		// The Microsoft Design Rules

		// A method is a good candidate to become a property
		// if one of these conditions is present:
		// 1. Takes no arguments and returns the state information of an object.
		// 2. Accepts a single argument to set some part of the state of an object.

		// Properties should behave as if they are fields;
		// if the method cannot, it should not be changed to a property.
		// Methods are better than properties in the following situations:

		// The Get method has an observable side effect. Retrieving the value of a field does not produce any side effects.
	}
}
