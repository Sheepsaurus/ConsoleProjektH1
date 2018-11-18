using System;

namespace ConsoleProjektH1
{
    public class Functions
    {
		public static readonly string Path = Environment.CurrentDirectory + "\\NameList.txt";
			
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