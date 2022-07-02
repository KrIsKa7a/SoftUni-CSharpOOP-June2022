namespace Person
{
    public class Person
    {
        //Fields are used only in getters and setters of the properties
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name; //setter
            this.Age = age;
        }

        //Properties are used in constructor, methods and public instances
        public string Name 
        {
            get
            {
                //Work with fields, never with the property itself
                return this.name;
            }
            set
            {
                this.name = value;
            } 
        }

        public int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    this.age = 0;
                }
                else
                {
                    this.age = value;
                }
            } 
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
