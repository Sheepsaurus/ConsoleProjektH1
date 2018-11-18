namespace Library
{
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
}