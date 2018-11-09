using System;
using System.Collections.Generic;

namespace ConsoleProjektH1
{
	class Program
	{
		private static void Main()
		{
			new Program().Run();
		}
		
		/// <summary>
		/// Handles user interface/experience and catches user errors
		/// </summary>
		private void Run()
		{
			try
			{
				Functions functions = new Functions();
				functions.ReadFile();
				Console.WriteLine("Hello, welcome to this list of people - Type \"help\" to " +
				                  "receive a list of commands");
				while (true)
				{
					Console.Write(":>");
					List<string> inputList = functions.FilterInput(Console.ReadLine()?.ToLower());
					try
					{
						Console.Clear();
						functions.HandleCommands(inputList, functions);
						Console.WriteLine("Please enter a command");
					}
					catch (Exception e)
					{
						if (inputList[0] == "changeperson" || inputList[0] == "changeage" ||
						    inputList[0] == "changebalance" || inputList[0] == "deleteperson" ||
						    inputList[0] == "addperson")
						{
							Console.WriteLine("That person is not on the list, or you entered an incorrect value");
						}
						else
						{
							Console.WriteLine("Please enter a name");
							Console.WriteLine(e);
						}
					}
				}
			}
			catch (Exception nfe)
			{
				Console.WriteLine(nfe);
			}
		}
	}
}