namespace P01.ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        //Magic numbers, strings from description -> private const inside the class
        private const int BoxPropertyMinValue = 0;
        private const string ZeroOrNegativeArgumentException =
            "{0} cannot be zero or negative.";

        //Validation -> Use private fileds + full property
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            //Always use properties if possible
            //When there is validation, ALWAYS USE THE PROPERTIES
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        //Length -> Property
        //length -> backing field
        public double Length
        {
            //Always use backing fields
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(
                        String.Format(ZeroOrNegativeArgumentException, 
                        nameof(this.Length)));
                }

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(
                        String.Format(ZeroOrNegativeArgumentException, nameof(this.Width)));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(
                        String.Format(ZeroOrNegativeArgumentException, nameof(this.Height)));
                }

                this.height = value;
            }
        }

        //Return some calculated result
        public double SurfaceArea()
            => (2 * this.Length * this.Width) + (2 * this.Length * this.Height) +
            (2 * this.Width * this.Height);

        public double LateralSurfaceArea()
            => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double Volume()
            => this.Length * this.Width * this.Height;

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output
                .AppendLine($"Surface Area - {this.SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.Volume():f2}");

            return output.ToString().TrimEnd();
        }
    }
}
