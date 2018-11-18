using System;
using System.Collections.Generic;
using Library;
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
			People.ReadFile();
			while (true)
			{
				WriteLine("Please enter a command");
				string[] result = ReadLine()?.ToLower().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
				Clear();
				CommandMethods.MainMethod(new List<string>(result ?? throw new InvalidOperationException()));
			}
		}
	}
}