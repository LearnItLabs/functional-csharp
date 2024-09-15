using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp
{
	public class Examples
	{


		// Pure functions are like mathematical functions:
		// they compute an output value based solely on their input values.
		// They perform no other actions in the code.

		public decimal CalculateDiscount(decimal amount, decimal discountRate)
		{
			return amount * (1 - discountRate);
		}

		public double CalculateRectArea(double width, double height) {
			return width * height;
		}
	
	}
}
