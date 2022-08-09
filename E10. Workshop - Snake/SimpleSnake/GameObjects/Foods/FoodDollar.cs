// ReSharper disable InconsistentNaming
namespace SimpleSnake.GameObjects.Foods
{
    using System;

    public class FoodDollar : Food
    {
        private const int foodPoints = 2;
        private const char foodSymbol = '$';
        private const ConsoleColor foodColor = ConsoleColor.Green;

        public FoodDollar(Field field) 
            : base(field, foodPoints, foodSymbol, foodColor)
        {

        }
    }
}
