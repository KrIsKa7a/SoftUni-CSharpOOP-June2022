namespace P04.WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier
            => OwlWeightMultiplier;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
