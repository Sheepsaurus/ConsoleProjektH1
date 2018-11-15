using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProjektH1
{
    /// <summary>
    /// A class to describe and contain the value of people
    /// </summary>
    public class Person
    {
		public string Name { get; set; }
		public int Age { get; set; }
		public double Balance { get; set; } 

		public Person(string name, int age, double balance)
        {
            Name = name;
            Age = age;
            Balance = balance;
        }
	}

	public class People
	{
		public static List<Person> people = new List<Person>();

		public void AddPerson(string name, int age, double balance) 
			=> people.Add(new Person(name, age, balance));

		public void DeletePerson(string name) 
			=> people.Remove(people.FirstOrDefault(x => x.Name == name));

		public void ChangeName(string oldName, string newName) 
			=> people.FirstOrDefault(x => x.Name == oldName).Name = newName;
		
		public void ChangeAge(string name, int age) 
			=> people.FirstOrDefault(x => x.Name == name).Age = age;
		
		public void ChangeBalance(string name, double balance) 
			=> people.FirstOrDefault(x => x.Name == name).Balance = balance;

	}
}