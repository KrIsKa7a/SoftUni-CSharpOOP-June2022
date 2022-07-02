namespace Animals
{
    using System;
    using System.Text;

    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        //Ctor can be used only for inheritance
        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    //null, "", "           "
                    throw new ArgumentNullException(nameof(this.Name), "Name cannot be null or whitespace!");
                }

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
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(this.Age), "Age must be positive number!");
                }

                this.age = value;
            } 
        }

        public string Gender 
        {
            get
            {
                return this.gender;
            } 
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Gender), "Gender cannot be null or whitespace!");
                }

                this.gender = value;
            } 
        }

        //No default behaviour
        //Behaviour will be determined in the inherited classes
        //Inherited classes must implement it!!!
        public abstract string ProduceSound();
        //{
        //    //No default sound for abstract animal
        //    return "What does the ANIMAL say???";
        //}

        //ToString() from inherited classes
        //Always will have a body for ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.GetType().Name}")
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .AppendLine($"{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}
