using System;

namespace Library
{
    public static class Functions
    {
        public static readonly string Path = Environment.CurrentDirectory + "\\NameList.txt";
			
        public static string Capitalize(string word)
        {
            if (word[0] == char.ToUpper(word[0])) return word;
            var newCharArray = word.ToCharArray();
            newCharArray[0] = char.ToUpper(word[0]);
            return new string(newCharArray);
        }					
    }
}