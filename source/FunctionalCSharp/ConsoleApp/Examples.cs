using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
public	class Examples
	{
		// Refactor the impure function to work 
		// exclusively with its input parameters.

		// This makes the code more testable.
		public DateTime GetCurrentTimeRoundedUpToCustomMinuteInterval(int interval, 
																																	DateTime startTime)
		{
			// 	var currentTime = DateTime.Now;
			var minutesSpan = TimeSpan.FromMinutes(interval).Ticks;

			if (startTime.Ticks % minutesSpan == 0)
			{
				return startTime;
			}
			else
			{
				return new DateTime((startTime.Ticks / minutesSpan + 1) * minutesSpan);
			}
			
		}

	}
}
