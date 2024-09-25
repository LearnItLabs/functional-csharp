using System;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{

			var examples = new Examples();
		
			examples.LinqExamples();
			examples.FilterExample();
			examples.TransformExample();
			examples.FunctionReturn();
		}
	}
}
