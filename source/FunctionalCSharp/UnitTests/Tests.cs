using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = ConsoleApp;
namespace UnitTests {
	[TestClass]
	public class SimpleColor_Should {
		[TestMethod]
		public void ReturnCorrectHexValue() {
			// arrange
			SUT.SimpleColor sColor;
			sColor = new SUT.SimpleColor(red: 09, green: 128, blue: 255);

			var hexValue = "#0980FF";

			// act
			var result = sColor.HexValue;
			// assert

			Assert.AreEqual(hexValue, result );

		}

		[TestMethod]
		public void SetCorrectHexValue() {
			// arrange
			SUT.SimpleColor sColor;
			sColor = new SUT.SimpleColor(red: 00, green: 00, blue: 00);

			var hexValue = "#0980FF";

			// act
			sColor.HexValue = hexValue;
			var result = sColor.HexValue;
			// assert

			Assert.AreEqual(hexValue, result);

		}
	}
}

