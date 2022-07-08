namespace MilitaryElite.Models.Contracts
{
    public interface ISoldier
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }
    }
}