namespace SimpleSnake
{
    using System;
    using Core;
    using Enums;
    using GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            DifficultyLevel diffLevel = PromptDifficultyLevel();

            Field field = new Field(60, 20);
            DisplayDifficulty(field, diffLevel);
            Snake snake = new Snake(field);

            IEngine engine = new Engine(field, snake, diffLevel);
            engine.Run();
        }

        private static DifficultyLevel PromptDifficultyLevel()
        {
            Console.WriteLine("Choose difficulty: ");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");

            Console.Write("Your choice: ");
            bool validInt = int.TryParse(Console.ReadLine(), out int diffLevelInt);
            if (!validInt)
            {
                Console.WriteLine("Invalid choice!");
                Console.WriteLine("Try again!");
                Main();
            }

            if (diffLevelInt < 1 || diffLevelInt > 3)
            {
                Console.WriteLine("Invalid choice!");
                Console.WriteLine("Try again!");
                Main();
            }

            DifficultyLevel diffLevel = (DifficultyLevel)diffLevelInt;

            Console.Clear();
            return diffLevel;
        }

        private static void DisplayDifficulty(Field field, DifficultyLevel level)
        {
            Console.SetCursorPosition(field.LeftX + 2, 1);
            Console.Write($"Difficulty level: {level.ToString()}");
        }
    }
}
