namespace PlayersAndMonsters
{

    using System;

    using PlayersAndMonsters.Models.Wizards;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            DarkWizard dw = new DarkWizard("Dark Wizard", 250);
            SoulMaster sm = new SoulMaster("Advanced Dark Wizard", 400);

            Console.WriteLine($"{dw} has {dw.Mana} mana!");
            Console.WriteLine($"{sm} has {sm.Mana} mana!");
        }
    }
}