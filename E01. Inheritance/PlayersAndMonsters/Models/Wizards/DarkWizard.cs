namespace PlayersAndMonsters.Models.Wizards
{
    public class DarkWizard : Wizard
    {
        private const int DefaultMana = 250;

        public DarkWizard(string username, int level, int mana = DefaultMana)
            : base(username, level, mana)
        {

        }
    }
}
