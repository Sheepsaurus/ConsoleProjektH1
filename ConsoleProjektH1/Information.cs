using System.Collections.Generic;
using System.Xml;

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

	    //Semi-Manual-Property
		public string Name { get => name; set => name = value; }
		public int Age { get => age; set => age = value; }
		public double Balance { get => balance; set => balance = value; }
		
	    /*
	     
	    //Auto-Property
		public string Name { get; set; }
		public int age { get; set; }
		public double balance { get; set; }

	    //Manual-Property
	    public string GetName()
	    {
		    return name;
	    }
	    
	    public void SetName(string newName)
	    {
		    name = newName;
	    }
	    
	    public int GetAge()
	    {
		    return age;
	    }
	    
	    public void SetAge(int newAge)
	    {
		    age = newAge;
	    }
	    
	    public double GetBalance()
	    {
		    return balance;
	    }
	    
	    public void SetBalance(double newBalance)
	    {
		    balance = newBalance;
	    }
	    
	    */
	    
		public Person(string name, int age, double balance)
        {
            this.name = name;
            this.age = age;
            this.balance = balance;
        }

	}

	public static class People
	{
		public static List<Person> people = new List<Person>();
	}
}