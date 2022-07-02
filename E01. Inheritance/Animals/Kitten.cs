namespace Animals
{
    public class Kitten : Cat
    {
        private const string DefGender = "Female";

        public Kitten(string name, int age) 
            : base(name, age, DefGender)
        {

        }

        //Abstract and virtual methods can be overriden more than once
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
