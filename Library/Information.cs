using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Library
{
    public static class People
	{
		private static List<Person> people = new List<Person>();
		
		public static void ReadFile()
		{
			if (!File.Exists(Functions.Path)) { File.WriteAllText(Functions.Path, ""); }

			File.ReadAllLines(Functions.Path).ToList().ForEach(x =>
			{
				string[] splitUp = x.Split(',');

				people.Add(new Person
				(
					Functions.Capitalize(splitUp[0]),
					int.Parse(splitUp[1]),
					double.Parse(splitUp[2])
				));
			});
		}

		public static void ShowAll()
		{
			int i = 15;
			Console.WriteLine("Name".PadRight(i) + "Age".PadRight(i) +
							  "Balance".PadRight(i));

			people.ForEach(person =>
			{
				if (person.Name.Length > i) i = person.Name.Length + 1;
				Console.WriteLine(person.Name.PadRight(i) + person.Age.ToString().PadRight(i) +
								  person.Balance.ToString(CultureInfo.InvariantCulture).PadRight(i));
			});

			Console.Write(Environment.NewLine);
		}

		private static void AppendNames()
		{
			File.WriteAllText(Functions.Path, "");			

			people.ForEach(person =>
			{
				File.AppendAllText(Functions.Path, 
					person.Name + "," + person.Age + "," + person.Balance + Environment.NewLine);
			});
		}

		public static int AddPerson(AddPerson o)
		{
			people.Add(new Person(Functions.Capitalize(o.Name), o.Age, o.Balance));
			Console.WriteLine($"{o.Name} was added");
			AppendNames();
			return 1;
		}

		public static int DeletePerson(DeletePerson o)
		{
			people.Remove(people.FirstOrDefault(x => x.Name == Functions.Capitalize(o.Name)));
			Console.WriteLine($"{o.Name} was deleted");
			AppendNames();
			return 1;
		}

		public static int ChangeName(ChangeName o)
		{
			people.First(x => x.Name == Functions.Capitalize(o.Name)).Name = Functions.Capitalize(o.newName);
			Console.WriteLine($"Their name was changed to {o.newName}");
			AppendNames();
			return 1;
		}

		public static int ChangeAge(ChangeAge o)
		{
			people.First(x => x.Name == Functions.Capitalize(o.Name)).Age = o.Age;
			Console.WriteLine($"Their age was changed to {o.Age}");
			AppendNames();
			return 1;
		}

		public static int ChangeBalance(ChangeBalance o)
		{
			people.First(x => x.Name == Functions.Capitalize(o.Name)).Balance = o.Balance;
			Console.WriteLine($"Their balance was changed to {o.Balance}");
			AppendNames();
			return 1;
		}
	}
}