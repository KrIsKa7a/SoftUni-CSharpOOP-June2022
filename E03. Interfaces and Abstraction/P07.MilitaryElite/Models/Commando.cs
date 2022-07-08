namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Enums;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            foreach (var currentMission in this.Missions)
            {
                sb.AppendLine($"  {currentMission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
