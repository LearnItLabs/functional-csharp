using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.FunctionalHelpers {












public static class Log {
	public static Func<string, Unit> LogMessage =  message  =>
	{
		Console.WriteLine(message);
		return Unit.Value;
	};
}
}
