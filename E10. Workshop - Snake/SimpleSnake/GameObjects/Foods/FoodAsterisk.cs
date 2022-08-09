// ReSharper disable InconsistentNaming
namespace SimpleSnake.GameObjects.Foods
{
    using System;

    public class FoodAsterisk : Food
    {
        private const int foodPoints = 1;
        private const char foodSymbol = '*';
        private const ConsoleColor foodColor = ConsoleColor.DarkYellow;

        public FoodAsterisk(Field field) 
            : base(field, foodPoints, foodSymbol, foodColor)
        {

        }
    }
}
