namespace PlayersAndMonsters.Models.Elfs
{
    public class Elf : Hero
    {
        public Elf(string username, int level, int arrows)
            : base(username, level)
        {
            Arrows = arrows;
        }

        public int Arrows { get; set; }
    }
}
