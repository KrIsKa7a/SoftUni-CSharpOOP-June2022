namespace MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICommando : ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get; }
    }
}