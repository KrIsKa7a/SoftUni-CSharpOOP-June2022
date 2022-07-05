namespace P01.ClassBoxData
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine(box);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
