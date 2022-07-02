namespace PlayersAndMonsters.Models.Knights
{
    public class DarkKnight : Knight
    {
        private const int DefaultStamina = 100;

        public DarkKnight(string username, int level, int stamina = DefaultStamina)
            : base(username, level, stamina)
        {

        }
    }
}
