// ReSharper disable InconsistentNaming
namespace SimpleSnake.GameObjects.Foods
{
    using System;

    public class FoodHash : Food
    {
        private const int foodPoints = 3;
        private const char foodSymbol = '#';
        private const ConsoleColor foodColor = ConsoleColor.Red;

        public FoodHash(Field field) 
            : base(field, foodPoints, foodSymbol, foodColor)
        {

        }
    }
}
