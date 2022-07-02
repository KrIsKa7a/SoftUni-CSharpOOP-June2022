namespace PlayersAndMonsters.Models.Wizards
{
    public class Wizard : Hero
    {
        public Wizard(string username, int level, int mana)
            : base(username, level)
        {
            Mana = mana;
        }

        public int Mana { get; set; }
    }
}
