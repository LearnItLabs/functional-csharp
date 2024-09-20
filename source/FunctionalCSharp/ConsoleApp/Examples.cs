using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp
{
	class Examples
	{
		public void DoWork() {
			RunIf();
			RunEndWith();
			RunPrime();
		}

		#region If Statements

		private void RunIf() {
			var currentProduct = new Product(productName: "Microphone", retailPrice: 200M);
			var salePriceA = GetProductPrice(product: currentProduct, 
																				quantity: 12, 
																				isPremiumCustomer: true);

			var salePriceB = GetProductPriceByExpression(product: currentProduct, 
																										quantity: 12, 																								isPremiumCustomer: true);
		}
		public decimal GetProductPrice(Product product, 
																	int quantity, 
																	bool isPremiumCustomer)
		{
			// statement version

			// note that the purpose of the if statement
			// is to mutate the value of the discountAmount variable
			// note that the discountAmount variable is declared outside the statements
			decimal discountAmount = 0;
			if (quantity > 10)
			{
				discountAmount += .15M;
			}
			if (isPremiumCustomer)
			{
				discountAmount += .05M;
			}
			return product.RetailPrice * (1 - discountAmount);

		}
		public decimal GetProductPriceByExpression(Product product, int quantity, bool isPremiumCustomer)
		{
			// expression version
			// In this version there is no mutation of variable, and also the code is more compact.

			// The conditional operator ?:, also known as the ternary conditional operator, 
			// evaluates a Boolean expression and returns the result of one of the two expressions,  depending on whether the Boolean expression evaluates to true or false.

			decimal discountAmount = (quantity > 10 ? .15M : 0) + (isPremiumCustomer ? .05M : 0) ;
		
			return product.RetailPrice * (1 - discountAmount);

			// expressions are more composable

		}
		#endregion

		#region Switch Statements

		public string GetColorHex(StandardColors colors)
		{
			string hexString = string.Empty;
			switch (colors)
			{
				case StandardColors.Red:
					hexString = "FF0000";
					break;
				case StandardColors.Orange:
					hexString = "FFA500";
					break;
				case StandardColors.Yellow:
					hexString = "FFFF00";
					break;
				case StandardColors.Green:
					hexString = "008000";
					break;
				case StandardColors.Blue:
					hexString = "0000FF";
					break;
				case StandardColors.Black:
					hexString = "FFFFFF";
					break;
				case StandardColors.White:
					hexString = "000000";
					break;
				default:
					hexString = "000000";
					break;
			}
			return hexString;
		}

		public string GetColorHexByExpression(StandardColors colors)
		{
			string hexString = colors switch
			{
				StandardColors.Red => "FF0000",
				StandardColors.Orange => "FFA500",
				StandardColors.Yellow => "FFFF00",
				StandardColors.Green => "008000",
				StandardColors.Blue => "0000FF",
				StandardColors.Black => "FFFFFF",
				StandardColors.White => "000000",
				_ => "000000",
			};
			return hexString;
		}

		#endregion

		#region ForEach

		public void RunEndWith() {
			List<int> targetNumbers = new List<int> { 14, 23, 37, 49 };
			// Generates numbers from 100 to 999
			List<int> allNumbers = Enumerable.Range(100, 900).ToList();
			var results1 = GetNumberEndingWith(targetNumbers, allNumbers);
			var results2 = GetNumberEndingWithExpression(targetNumbers, allNumbers);
		}
		public List<int> GetNumberEndingWith(List<int> targetNumbers, List<int> allNumbers) {
			List<int> matchingNumbers = new List<int>();

			foreach (var number in allNumbers)
			{
				foreach (var target in targetNumbers)
				{
					if (number % 100 == target) // Check if the number ends with the target number
					{
						matchingNumbers.Add(number);
						break; // Break to avoid adding the same number multiple times
					}
				}
			}
			return matchingNumbers;
		}

		public List<int> GetNumberEndingWithExpression(List<int> targetNumbers, List<int> allNumbers) {
			return allNumbers
				.Where(number => targetNumbers.Any(target => number % 100 == target))
				.ToList();
		}

		#endregion

		#region IsPrime
		private void RunPrime() {
			var q = from allNumber in Enumerable.Range(1, 1000)
							where IsPrime(allNumber)
							select allNumber;
			var result = q.ToList();
		}
		bool IsPrime(int number) => number > 1 && Enumerable
														.Range(2, (int)Math.Sqrt(number) - 1)
														.All(divisor => number % divisor != 0);
		#endregion

		#region Types
		public enum StandardColors
		{
			Red,
			Orange,
			Yellow,
			Green,
			Blue,
			Indigo,
			Violet,
			Black,
			White
		}
	}
	public class Product
	{
		public decimal RetailPrice { get; }
		public string ProductName { get; }

		public Product(string productName, decimal retailPrice)
		{
			ProductName = productName;
			RetailPrice = retailPrice;

		}
		public Product AdjustPrice(decimal newPrice) { 
			return new Product(productName: ProductName, retailPrice: newPrice);
		}
			#endregion
		}
	}
