using System.Collections.Generic;

namespace ConsoleProjektH1
{
    /// <summary>
    /// A class to describe and contain the value of people
    /// </summary>
    public class Person
    {
		public static List<Person> people = new List<Person>();

		public string name;
        public int age;
        public double balance;
        
        public Person(string name, int age, double balance)
        {
            this.name = name;
            this.age = age;
            this.balance = balance;
        }
    }
}