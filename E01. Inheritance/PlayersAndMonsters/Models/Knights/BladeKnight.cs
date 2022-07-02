namespace PlayersAndMonsters.Models.Knights
{
    public class BladeKnight : DarkKnight
    {
        private const int DefaultStamina = 300;

        public BladeKnight(string username, int level)
            : base(username, level, DefaultStamina)
        {

        }
    }
}
