using System.Collections.Generic;

namespace ConsoleProjektH1
{
    /// <summary>
    /// A class to describe and contain the value of people
    /// </summary>
    public class Person
    {
		private string name;
		private int age;
		private double balance;

		public string Name { get => name; set => name = value; }
		public int Age { get => age; set => age = value; }
		public double Balance { get => balance; set => balance = value; }

		//public string Name { get; set; }
		//public int age { get; set; }
		//public double balance { get; set; }

		public Person(string name, int age, double balance)
        {
            this.name = name;
            this.age = age;
            this.balance = balance;
        }

	}

	public class People
	{
		public static List<Person> people = new List<Person>();
	}
}