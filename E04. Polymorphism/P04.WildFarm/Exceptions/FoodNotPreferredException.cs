namespace P04.WildFarm.Exceptions
{
    using System;

    public class FoodNotPreferredException : Exception
    {
        public FoodNotPreferredException(string message)
            : base(message)
        {
            
        }
    }
}
