using System;
using System.Globalization;

namespace ConsoleApp {
	public class SimpleColor {

		// Mutable fields
		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }

		// Constructor to set the color values
		public SimpleColor(byte red, byte green, byte blue) {
			Red = red;
			Green = green;
			Blue = blue;
		}
		// Property to set or calculate and return the Hex value of the color
		public string HexValue
		{
			get
			{
				return $"#{Red:X2}{Green:X2}{Blue:X2}";
			}

			set
			{
				// Ensure the input is a valid hex color string
				if (value.StartsWith("#") && value.Length == 7)
				{
					#region Comment about this section
					// This is impure, we are changing the state of the
					// Red, Green and Blue properties inside this method! 
					#endregion
					Red = byte.Parse(value.Substring(1, 2), NumberStyles.HexNumber);
					Green = byte.Parse(value.Substring(3, 2), NumberStyles.HexNumber);
					Blue = byte.Parse(value.Substring(5, 2), NumberStyles.HexNumber);
				}
				else
				{
					throw new ArgumentException("Invalid Hex format. Use a format like '#RRGGBB'.");
				}
			}
		}

	}

}
