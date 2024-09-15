using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests {
	[TestClass]
	public class APureFunction_Should {
		[TestMethod]
		public void ReturnSameResults_WhenSameInputs() {
			// arrange
			var examples = new Examples();
			decimal salesAmount = 50M;
			decimal discount = .3M;
			// act
			var result1 = examples.CalculateDiscount(salesAmount, discount);
			var result2 = examples.CalculateDiscount(salesAmount, discount);

			// assert
			Assert.AreEqual((salesAmount * (1 - discount)), result1);
			Assert.AreEqual(result1, result2);
		}


		[TestMethod]
		public void ReturnSalesAmount_WhenZeroDiscount() {
			// arrange
			var examples = new Examples();
			decimal salesAmount = 50M;
			decimal discount = .0M;
			// act
			var result1 = examples.CalculateDiscount(salesAmount, discount);
			

			// assert
			Assert.AreEqual(salesAmount , result1);
		
		}

		[TestMethod]
		public void ReturnArea_WhenValidArgs() {
			// arrange
			var examples = new Examples();
			double width = 10;
			double height = 20;
			// act
			var area = examples.CalculateRectArea(width, height);


			// assert
			Assert.AreEqual(expected: 200, actual: area);

		}
	}
}
