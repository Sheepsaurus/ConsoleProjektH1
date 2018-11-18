using System;
using System.Collections.Generic;
using CommandLine;

namespace ConsoleProjektH1
{
	class CommandMethods
	{
		public static int MainMethod(List<string> inputList) => 
			Parser.Default.ParseArguments<AddPerson, DeletePerson, ChangeName, ChangeAge, ChangeBalance, Quit, ShowAll>
			(inputList).MapResult((AddPerson opts)	   => People.AddPerson(opts), 
								  (DeletePerson opts)  => People.DeletePerson(opts), 
								  (ChangeName opts)    => People.ChangeName(opts), 
								  (ChangeAge opts)     => People.ChangeAge(opts), 
								  (ChangeBalance opts) => People.ChangeBalance(opts), 
								  (Quit opts)          => Quit(opts), 
								  (ShowAll opts)       => ShowAll(opts), 
														  errs => 1);

		static int Quit(Quit o)
		{
			Environment.Exit(0);
			return 1;
		}
		static int ShowAll(ShowAll o)
		{
			new People().ShowAll();
			return 1;
		}	
	}

	[Verb("addperson", HelpText = "Add a person - Syntax: addperson -n <Name> -a <Age> -b <Balance>")]
	public class AddPerson
	{
		[Option('n', "name", Required = true, HelpText = "Name of the person")]
		public string Name { get; set; }
		[Option('a', "age", Required = true, HelpText = "Age of the person")]
		public int Age { get; set; }
		[Option('b', "balance", Required = true, HelpText = "Balance of the person")]
		public double Balance { get; set; }
	}

	[Verb("deleteperson", HelpText = "Delete a person - Syntax: deleteperson -n <Name>")]
	public class DeletePerson
	{
		[Option('n', "name", Required = true, HelpText = "Name of the person")]
		public string Name { get; set; }
	}

	[Verb("changename", HelpText = "change a persons name - Syntax: changename -n <Name> -e <newName>")]
	public class ChangeName
	{
		[Option('n', "name", Required = true, HelpText = "Name of the person")]
		public string Name { get; set; }
		[Option('e', "ename", Required = true, HelpText = "New name of the person")]
		public string newName { get; set; }
	}

	[Verb("changeage", HelpText = "change a persons age - Syntax: changeage -n <Name> -a <Age>")]
	public class ChangeAge
	{
		[Option('n', "name", Required = true, HelpText = "Name of the person")]
		public string Name { get; set; }
		[Option('a', "age", Required = true, HelpText = "Age of the person")]
		public int Age { get; set; }
	}

	[Verb("changebalance", HelpText = "change a persons balance - Syntax: changebalance -n <Name> -b <Balance>")]
	public class ChangeBalance
	{
		[Option('n', "name", Required = true, HelpText = "Name of the person")]
		public string Name { get; set; }
		[Option('b', "balance", Required = true, HelpText = "Balance of the person")]
		public double Balance { get; set; }
	}

	[Verb("quit", HelpText = "quit the application - Syntax: quit")]
	public class Quit
	{
	}

	[Verb("showall", HelpText = "show the entire list - Syntax: showall")]
	public class ShowAll
	{
	}
}
