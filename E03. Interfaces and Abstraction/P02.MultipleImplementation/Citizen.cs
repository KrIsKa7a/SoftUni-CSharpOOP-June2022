namespace P02.MultipleImplementation
{
    using Interfaces;

    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        //No validations -> use auto-properties (short)
        //Validation -> use full properties + fields (long)
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
