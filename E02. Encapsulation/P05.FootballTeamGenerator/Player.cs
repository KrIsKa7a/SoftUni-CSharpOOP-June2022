namespace P05.FootballTeamGenerator
{
    using System;

    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                //True -> null, '', '   '
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhitespaceName);
                }

                this.name = value;
            }
        }

        public Stats Stats { get; private set; }

        //5 integer properties
    }
}
