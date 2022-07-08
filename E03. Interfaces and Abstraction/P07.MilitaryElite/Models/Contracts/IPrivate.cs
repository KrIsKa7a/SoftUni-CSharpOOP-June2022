namespace MilitaryElite.Models.Contracts
{
    public interface IPrivate : ISoldier
    {
        public decimal Salary { get; }
    }
}
