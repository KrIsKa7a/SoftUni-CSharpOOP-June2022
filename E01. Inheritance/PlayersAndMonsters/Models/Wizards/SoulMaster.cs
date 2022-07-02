namespace PlayersAndMonsters.Models.Wizards
{
    public class SoulMaster : DarkWizard
    {
        private const int DefaultMana = 800;

        public SoulMaster(string username, int level)
            : base(username, level, DefaultMana)
        {

        }
    }
}
