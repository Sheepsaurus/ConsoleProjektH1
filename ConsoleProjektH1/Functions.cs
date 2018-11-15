using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleProjektH1
{
    public class Functions
    {
        /// <summary>
		/// Shows the entire current list, fetched from the file
		/// </summary>
		private void ShowAll()
		{
			int i = 15;
			Console.WriteLine("Name".PadRight(i) + "Age".PadRight(i) + 
			                  "Balance".PadRight(i));
			
			foreach (var person in People.people)
			{
				if (person.Name.Length > i)
					i = person.Name.Length + 1;

				Console.WriteLine(person.Name.PadRight(i) + person.Age.ToString().PadRight(i) +
								  person.Balance.ToString().PadRight(i));
			}
			Console.Write(Environment.NewLine);
		}		
		
		/// <summary>
		/// Appends the names from the list of people to the .txt-file, separated by ',' and '\n'
		/// </summary>
		public void AppendNames()
		{
			File.WriteAllText(Environment.CurrentDirectory + "\\NameList.txt", "");

			for (int i = 0; i < People.people.Count; i++) 
			{ 
				Person p = new Person
				(
					Capitalize
					(People.people[i].Name),
					 People.people[i].Age,
					 People.people[i].Balance
				);

				File.AppendAllText(Environment.CurrentDirectory + "\\NameList.txt", 
					p.Name + "," + p.Age + "," + p.Balance + Environment.NewLine);
			}
		}

		/// <summary>
		/// Capitalizes the first letter in a string / char array
		/// </summary>
		/// <param name="word"></param>
		/// <returns>A string with the first letter of the string, capitalized</returns>
		public string Capitalize(string word)
		{
			if (word[0] != char.ToUpper(word[0]))
			{
				var newCharArray = word.ToCharArray();
				if (word != "")
				{
					newCharArray[0] = char.ToUpper(word[0]);
				}
				return new string(newCharArray).Replace(" ", "");
			}
			return word.Replace(" ", "");			
		}

		/// <summary>
		/// Takes the input given by the user
		/// </summary>
		/// <param name="input"></param>
		/// <returns>Returns the input, split up by whitespace</returns>
		public List<string> FilterInput(string input)
			=> new List<string>(input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));

		/// <summary>
		/// A method that can read the NameList file, and split up the containing lines by ',' to retrieve the
		/// information for use
		/// </summary>
		public void ReadFile()
		{
			foreach (var line in File.ReadAllLines(Environment.CurrentDirectory + "\\NameList.txt"))
			{
				string[] splitUp = line.Split(',');

				People.people.Add(new Person
				(
					Capitalize(splitUp[0]), 
					int.Parse(splitUp[1]), 
					double.Parse(splitUp[2])
				));
			}
		}
		
		/// <summary>
		/// A method containing a switch, that handles the entire collection of commands.
		/// </summary>
		/// <param name="inputList"></param>
		/// <param name="functions"></param>
		public void HandleCommands(List<string> inputList)
		{
			People p = new People();

			string firstName = "";
			string secondName = "";
			int age = 0;
			double balance = 0;

			if (inputList.Count == 4)
			{
				firstName = inputList[1] != null ? Capitalize(inputList[1]) : "";
				secondName = inputList[2] != null ? Capitalize(inputList[2]) : "";
				age = inputList[2] != null ? int.Parse(inputList[2]) : 0;
				balance = inputList[3] != null ? double.Parse(inputList[3]) : 0;
			}
			else if (inputList.Count == 3)
			{
				firstName = inputList[1] != null ? Capitalize(inputList[1]) : "";
				secondName = inputList[2] != null ? Capitalize(inputList[2]) : "";
				
				if (int.TryParse(inputList[2], out int result))
				{
					age = result;
				}				
			}
			else if (inputList.Count == 2)
			{
				firstName = inputList[1] != null ? Capitalize(inputList[1]) : "";
			}			

			switch (inputList[0])
			{
				case "showall":
					ShowAll();
					break;
				case "addperson":
					p.AddPerson(firstName, age, balance);
					AppendNames();
					Console.WriteLine($"{firstName} was added");
					break;
				case "deleteperson":
					p.DeletePerson(firstName);
					AppendNames();
					Console.WriteLine($"{firstName} was deleted");
					break;
				case "changeperson":
					p.ChangeName(firstName, secondName);
					AppendNames();
					Console.WriteLine($"{firstName}'s name was changed to {secondName}");
					break;
				case "changeage":
					p.ChangeAge(firstName, age);
					AppendNames();
					Console.WriteLine($"{firstName}'s age was changed to {age}");
					break;
				case "changebalance":
					p.ChangeBalance(firstName, balance);
					AppendNames();
					Console.WriteLine($"{firstName}'s balance was changed to {balance}");
					break;
				case "clear":
					Console.Clear();
					Console.WriteLine("Hello, welcome to this list of people - Type \"help\" to receive a list of commands");
					break;
				case "quit":
					Environment.Exit(0);
					break;
				case "help":
					Console.WriteLine(
						"These are the available commands:  \n\n" +
						" \"showall\" - Shows the current list of people\n" + 
						" \"addperson\" <name> <age> <balance> - Adds a person to the current list of people\n" + 
						" \"deleteperson\" <name> - Deletes a person from the current list of people\n" +
						" \"changeperson\" <oldname> <newname> - changes the name of a person from the current list of people\n" + 
						" \"changeage\" <name> <newage> - changes the age of a person from the current list of people\n" +
						" \"changebalance\" <name> <newbalance> - changes the balance of a person from the current list of people\n" + 
						" \"quit\" - Quits the console\n" + 
						" \"help\" - Shows this list of available commands");
					break;
				default:
					Console.WriteLine("That is not a command");
					break;
			}
		}
    }
}