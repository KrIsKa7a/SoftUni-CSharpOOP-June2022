namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DefGender = "Male";

        public Tomcat(string name, int age) 
            : base(name, age, DefGender)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
