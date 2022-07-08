namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Enums;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly Dictionary<int, ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] inputInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string result = this.Read(inputInfo);

                    Console.WriteLine(result);
                }
                catch (Exception)
                {}

                input = Console.ReadLine();
            }
        }

        public string Read(string[] args)
        {
            string soldierType = args[0];
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];

            ISoldier soldier = null;

            if (soldierType == "Private")
            {
                decimal salary = decimal.Parse(args[4]);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (soldierType == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(args[4]);
                var privates = new Dictionary<int, IPrivate>();

                for (int i = 5; i < args.Length; i++)
                {
                    int soldierId = int.Parse(args[i]);
                    var currentSoldier = (IPrivate)soldiers[soldierId];
                    privates.Add(soldierId, currentSoldier);
                }

                soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
            }
            else if (soldierType == "Engineer")
            {
                decimal salary = decimal.Parse(args[4]);
                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if (!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<IRepair> repairs = new List<IRepair>();

                for (int i = 6; i < args.Length; i += 2)
                {
                    string currentName = args[i];
                    int hours = int.Parse(args[i + 1]);
                    IRepair repair = new Repair(currentName, hours);
                    repairs.Add(repair);
                }

                soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
            }
            else if (soldierType == "Commando")
            {
                decimal salary = decimal.Parse(args[4]);
                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if (!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<IMission> missions = new List<IMission>();

                for (int i = 6; i < args.Length; i += 2)
                {
                    string missionName = args[i];
                    string missionState = args[i + 1];

                    bool isValidMissionState = Enum.TryParse<State>(missionState, out State stateResult);

                    if (!isValidMissionState)
                    {
                        continue;
                    }

                    IMission mission = new Mission(missionName, stateResult);
                    missions.Add(mission);
                }

                soldier = new Commando(id, firstName, lastName, salary, corps, missions);
            }
            else if (soldierType == "Spy")
            {
                int codeNumber = int.Parse(args[4]);
                soldier = new Spy(id, firstName, lastName, codeNumber);
            }

            soldiers.Add(id, soldier);

            return soldier.ToString();
        }
    }
}
