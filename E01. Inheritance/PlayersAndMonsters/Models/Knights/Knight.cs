namespace PlayersAndMonsters.Models.Knights
{
    public class Knight : Hero
    {
        public Knight(string username, int level, int stamina)
            : base(username, level)
        {
            Stamina = stamina;
        }

        public int Stamina { get; set; }
    }
}
