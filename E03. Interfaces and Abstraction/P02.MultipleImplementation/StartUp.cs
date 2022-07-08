namespace P02.MultipleImplementation
{
    using System;
    using Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();

            //Interfaces are not instantiated
            //We create object from class Citizen and assign it to variable of type IIdentifable
            //We hide the Citizen object behind its interface
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
            //double num = (int)5;

            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
