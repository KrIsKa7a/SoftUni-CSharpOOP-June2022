namespace MilitaryElite.Models.Contracts
{
    using Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
