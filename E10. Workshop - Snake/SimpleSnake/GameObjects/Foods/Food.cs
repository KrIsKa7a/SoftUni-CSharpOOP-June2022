namespace SimpleSnake.GameObjects.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Random random;

        private readonly Field field;
        private readonly ConsoleColor foodColor;

        protected Food(Field field, int foodPoints, char foodSymbol, ConsoleColor foodColor)
            : base(field.LeftX, field.TopY)
        {
            this.random = new Random();

            this.field = field;
            this.FoodPoints = foodPoints;
            this.FoodSymbol = foodSymbol;
            this.foodColor = foodColor;
        }

        public int FoodPoints { get; }

        public char FoodSymbol { get; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            do
            {
                LeftX = random.Next(2, this.field.LeftX - 2);
                TopY = random.Next(2, this.field.TopY - 2);
            } while (snake.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY));

            Console.BackgroundColor = this.foodColor;
            this.Draw(FoodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return this.LeftX == snakeHead.LeftX &&
                   this.TopY == snakeHead.TopY;
        }
    }
}
