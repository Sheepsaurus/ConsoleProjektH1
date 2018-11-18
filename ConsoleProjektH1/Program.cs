using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace ConsoleProjektH1
{
	class Program
	{
		private static void Main()
		{
			RunInputLogic();
		}

		private static void RunInputLogic()
		{			
			while (true)
			{
				WriteLine("Please enter a command");
				string[] result = ReadLine()?.ToLower().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
				Clear();
				CommandMethods.MainMethod(new List<string>(result));
			}
		}
	}
}