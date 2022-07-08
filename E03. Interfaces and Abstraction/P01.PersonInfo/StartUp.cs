namespace PersonInfo
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //Interface -> public side of our class
            //Interface -> define public visibility of our class
            //Interface -> Communication between classes
            //Using Interfaces -> Abstraction level increasment
            //Abstraction in Bussiness logic of the application -> Core class
            //Work with interfaces without knowing the concrete implementation
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            IPerson person = new Citizen(name, age);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
            //This does not exists in the interface IPerson
            //Console.WriteLine(person.Sleep());
        }
    }
}
