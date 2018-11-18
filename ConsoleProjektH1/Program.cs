using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace ConsoleProjektH1
{
	class Program
	{
		private static void Main() => new Program().Run();
		
		private void Run()
		{			
			if (!File.Exists(Functions.Path)) { File.WriteAllText(Functions.Path, ""); }				
				
			ReadFile();
			WriteLine("Hello, welcome to this list of people - Type \"help\" to receive a list of commands");

			while (true)
			{
				Write(":>");
				var result = ReadLine()?.ToLower().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				Clear();
				Commands.MainMethod(new List<string>(result));
				WriteLine("\nPlease enter a command");					
			}
		}
		void ReadFile()
		{
			File.ReadAllLines(Functions.Path).ToList().ForEach(x =>
			{
				string[] splitUp = x.Split(',');

				People.people.Add(new Person
				(
					Functions.Capitalize(splitUp[0]),
					int.Parse(splitUp[1]),
					double.Parse(splitUp[2])
				));
			});
		}
	}
}