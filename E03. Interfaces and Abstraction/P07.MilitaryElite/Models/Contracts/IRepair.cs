namespace MilitaryElite.Models.Contracts
{
    public interface IRepair
    {
        public string PartName { get; }

        public int HoursWorked { get; }
    }
}
