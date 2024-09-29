using ConsoleApp.FunctionalHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
	class Examples
	{

		public void UseUnit()
		{
			Unit result;
			result = Log.LogMessage("hello");
			result = Log.LogMessage("goodbye");
		}
	}
}
