namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) 
            : base(name, age) //Before executing Child ctor, first exec Base contructor
        {
            //No logic inside
        }
    }
}
