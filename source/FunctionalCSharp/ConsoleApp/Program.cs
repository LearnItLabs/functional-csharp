using System;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var examples = new Examples();
			examples.CreateRandomIntegers();
			examples.CreateRandomFromSystemClock();
			examples.CreateRandomIntegersInRange();
			examples.CreateRandomOtherTypes();
		
			examples.CreateARandomList();
			examples.OrderListRandomly();
			

		}
	}
}
