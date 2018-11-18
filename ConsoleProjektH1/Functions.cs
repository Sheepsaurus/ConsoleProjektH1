using System;

namespace ConsoleProjektH1
{
    public class Functions
    {
		public static readonly string Path = Environment.CurrentDirectory + "\\NameList.txt";
		
		public void ShowAll()
		{
			int i = 15;
			Console.WriteLine("Name".PadRight(i) + "Age".PadRight(i) + 
			                  "Balance".PadRight(i));

			People.people.ForEach(person =>
			{
				if (person.Name.Length > i) i = person.Name.Length + 1;
				Console.WriteLine(person.Name.PadRight(i) + person.Age.ToString().PadRight(i) +
								  person.Balance.ToString().PadRight(i));
			});
			
			Console.Write(Environment.NewLine);
		}		
		
		public static string Capitalize(string word)
		{
			if (word[0] != char.ToUpper(word[0]))
			{
				var newCharArray = word.ToCharArray();
				newCharArray[0] = char.ToUpper(word[0]);
				return new string(newCharArray);
			}
			return word;			
		}					
	}
}