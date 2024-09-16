using System;
using System.Threading;

namespace ConsoleApp
{
	class Program
	{

		static void Main(string[] args)
		{

			Timer t = new Timer(TimerCallback, null, 0, 1000);
			Console.ReadLine();
			
		}
			private static void TimerCallback(Object o)
			{
			var examples = new Examples();
			Console.Clear();

		}
		
	}
}
