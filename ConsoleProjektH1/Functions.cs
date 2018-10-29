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
		/// <param name="people"></param>
		private void ShowAll(List<Person> people)
		{
			int i = 20;

			Console.WriteLine("Name".PadRight(i) + "Age".PadRight(i-2) + 
			                  "Balance".PadRight(i));
			
			foreach (var person in people)
			{
				if (person.Name.Length > i)
					i = person.Name.Length + 1;
				
				Console.WriteLine(person.Name.PadRight(i) + person.Age.ToString().PadRight(i-2) + 
				                  person.Balance.ToString().PadRight(i));
			}
		}

		/// <summary>
		/// Adds a person at the end of the list, then appends the person to the .txt-file
		/// </summary>
		/// <param name="people"></param>
		/// <param name="name"></param>
		/// <param name="age"></param>
		/// <param name="balance"></param>
		private void AddPerson(List<Person> people, string name, int age, double balance)
		{
			people.Add(new Person(Capitalize(name), age, balance));
			AppendNames(people);
			Console.WriteLine("Person added\n");
		}

		/// <summary>
		/// Removes a person with a specific name, then appends to the .txt-file
		/// </summary>
		/// <param name="people"></param>
		/// <param name="b"></param>
		private void DeletePerson(List<Person> people, string b)
		{
			for (var i = 0; i < people.Count; i++)
			{
				if (people[i].Name == Capitalize(b))
				{
					people.Remove(people[i]);
				}
			}
			
			AppendNames(people);

			Console.WriteLine("Person deleted\n");
		}
		
		/// <summary>
		/// Changes the person with a specific name, to another name, then appends to the .txt-file
		/// </summary>
		/// <param name="people"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		private void ChangeName(List<Person> people, string a, string b)
		{
			foreach (var person in people)
			{
				if (person.Name == Capitalize(a))
				{
					person.Name = Capitalize(b);
				}
			}
			AppendNames(people);
			
			Console.WriteLine("Person changed\n");
		}

		/// <summary>
		/// Changes the person with a specific name, to a different age, then appends to the .txt-file
		/// </summary>
		/// <param name="people"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		private void ChangeAge(List<Person> people, string a, int b)
		{
			foreach (var person in people)
			{
				if (person.Name == Capitalize(a))
				{
					person.Age = b;
				}
			}
			AppendNames(people);
			
			Console.WriteLine("Age changed\n");
		}

		/// <summary>
		/// Changes the person with a specific name, to a different balance
		/// </summary>
		/// <param name="people"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		private void ChangeBalance(List<Person> people, string a, double b)
		{
			foreach (var person in people)
			{
				if (person.Name == Capitalize(a))
				{
					person.Balance = b;
				}
			}
			AppendNames(people);
			
			Console.WriteLine("Balance changed\n");
		}
		
		/// <summary>
		/// Appends the names from the list of people to the .txt-file, separated by ',' and '\n'
		/// </summary>
		/// <param name="people"></param>
		private void AppendNames(List<Person> people)
		{
			File.WriteAllText(Environment.CurrentDirectory + "\\NameList.txt", "");

			foreach (var person in people)
			{
				File.AppendAllText(Environment.CurrentDirectory + "\\NameList.txt", 
					Capitalize(person.Name) + "," + person.Age + "," +  person.Balance + Environment.NewLine);
			}
		}

		/// <summary>
		/// Capitalizes the first letter in a string / char array
		/// </summary>
		/// <param name="a"></param>
		/// <returns>A string with the first letter of the string, capitalized</returns>
		private string Capitalize(string a)
		{
			if (a[0] != char.ToUpper(a[0]))
			{
				var newCharArray = a.ToCharArray();
				if (a != "")
				{
					newCharArray[0] = char.ToUpper(a[0]);
				}
				return new string(newCharArray).Replace(" ", "");
			}
			else
			{
				return a.Replace(" ", "");
			}
		}

		/// <summary>
		/// Takes the input given by the user
		/// </summary>
		/// <param name="input"></param>
		/// <returns>Returns the input, split up by whitespace</returns>
		public List<string> FilterInput(string input)
		{
			return new List<string>(input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
		}
		
		/// <summary>
		/// A method that can read the NameList file, and split up the containing lines by ',' to retrieve the
		/// information for use
		/// </summary>
		/// <param name="people"></param>
		public void ReadFile(List<Person> people)
		{
			string[] peopleArray = File.ReadAllLines(Environment.CurrentDirectory + "\\NameList.txt");

			foreach (var t in peopleArray)
			{
				var splitUp = t.Split(',');
				
				people.Add(new Person(Capitalize(splitUp[0]), int.Parse(splitUp[1]), double.Parse(splitUp[2])));
			}
		}
		
		/// <summary>
		/// A method containing a switch, that handles the entire collection of commands.
		/// </summary>
		/// <param name="people"></param>
		/// <param name="inputList"></param>
		/// <param name="functions"></param>
		public void HandleCommands(List<Person> people, List<string> inputList, Functions functions)
		{
			switch (inputList[0])
			{
				case "showall":
					functions.ShowAll(people);
					break;
				case "addperson":
					functions.AddPerson(people, inputList[1], int.Parse(inputList[2]), double.Parse(inputList[3]));
					break;
				case "deleteperson":
					functions.DeletePerson(people, inputList[1]);
					break;
				case "changeperson":
					functions.ChangeName(people, inputList[1], inputList[2]);
					break;
				case "changeage":
					functions.ChangeAge(people, inputList[1], int.Parse(inputList[2]));
					break;
				case "changebalance":
					functions.ChangeBalance(people, inputList[1], double.Parse(inputList[2]));
					break;
				case "clear":
					Console.Clear();
					Console.WriteLine("Hello, welcome to this list of people - Type \"help\" to " +
					                  "receive a list of commands");
					break;
				case "quit":
					Environment.Exit(0);
					break;
				case "help":
					Console.WriteLine("These are the available commands:");
					Console.WriteLine("\"showall\" - Shows the current list of people");
					Console.WriteLine("\"addperson\" <name> <age> <balance> - Adds a person to the " +
					                  "current list of people");
					Console.WriteLine("\"deleteperson\" <name> - Deletes a person from the current list of people");
					Console.WriteLine("\"changeperson\" <oldname> <newname> - changes the name of a person from the " +
					                  "current list of people");
					Console.WriteLine("\"changeage\" <name> <newage> - changes the age of a person from the " +
					                  "current list of people");
					Console.WriteLine("\"changebalance\" <name> <newbalance> - changes the balance of a person " +
					                  "from the current list of people");
					Console.WriteLine("\"clear\" - Clears the console");
					Console.WriteLine("\"quit\" - Quits the console");
					Console.WriteLine("\"help\" - Shows this list of available commands");
					break;
				default:
					Console.WriteLine("That is not a command");
					break;
			}
		}
    }
}