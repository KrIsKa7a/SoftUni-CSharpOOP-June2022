namespace PlayersAndMonsters.Models.Elfs
{
    public class MuseElf : Elf
    {
        private const int DefaultArrows = 150;

        public MuseElf(string username, int level)
            : base(username, level, DefaultArrows)
        {

        }
    }
}
