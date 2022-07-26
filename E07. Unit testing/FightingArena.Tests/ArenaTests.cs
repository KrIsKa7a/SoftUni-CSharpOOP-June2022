namespace FightingArena.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestConstructorInitializesEmptyCollectionOfWarrior()
        {
            Arena testArena = new Arena();

            List<Warrior> actualCollection = testArena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>();

            CollectionAssert.AreEqual(expectedCollection, actualCollection,
                "Arena constructor should initialize an empty collection for Warriors!");
        }

        [Test]
        public void TestIfWarriorsCollectionIsEncapsulatedProperly()
        {
            string actualType = typeof(Arena)
                .GetProperties()
                .First(pi => pi.Name == "Warriors")
                .PropertyType
                .Name;
            string expectedType = typeof(IReadOnlyCollection<Warrior>).Name;

            Assert.AreEqual(expectedType, actualType,
                "Property for the enrolled Warriors should be of type IReadOnlyCollection<Warrior>!");
        }

        [Test]
        public void CountShouldReturnZeroOnEmptyArena()
        {
            int actualCount = this.arena.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return zero when there are no enrolled Warriors!");
        }

        [Test]
        public void CountShouldReturnCorrectValueWhenThereAreEnrolledWarriors()
        {
            //Act
            Warrior warrior = new Warrior("Pesho", 50, 100);
            this.arena.Enroll(warrior);

            int actualCount = this.arena.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return the count of the enrolled Warriors!");
        }

        [Test]
        public void TestEnrollAddsWarriorsToTheArena()
        {
            Warrior pesho = new Warrior("Pesho", 30, 100);
            Warrior gosho = new Warrior("Gosho", 35, 85);

            this.arena.Enroll(pesho);
            this.arena.Enroll(gosho);

            List<Warrior> actualCollection = this.arena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>()
            {
                pesho,
                gosho
            };

            CollectionAssert.AreEqual(expectedCollection, actualCollection,
                "Warriors collection getter should return enrolled warriors!");
        }

        [Test]
        public void EnrollShouldThrowAnExceptionWhenEnrollingExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void FightBetweenInExistingAttackerShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Invalid", "Pesho");
            }, "There is no fighter with name Invalid enrolled for the fights!");
        }

        [Test]
        public void FightBetweenInExistingDefenderShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Pesho", "Invalid");
            }, "There is no fighter with name Invalid enrolled for the fights!");
        }

        [Test]
        public void FightBetweenExistingWarriorsShouldSucceed()
        {
            Warrior warriorA = new Warrior("Pesho", 40, 100);
            Warrior warriorD = new Warrior("Gosho", 55, 100);

            this.arena.Enroll(warriorA);
            this.arena.Enroll(warriorD);

            this.arena.Fight("Pesho", "Gosho");

            int actualAttackerHp = warriorA.HP;
            int expectedAttackerHp = 100 - warriorD.Damage;

            int actualDefenderHp = warriorD.HP;
            int expectedDefenderHp = 100 - warriorA.Damage;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp, 
                "Fight between existing Warriors should decrease attacker HP!");
            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, 
                "Fight between existing Warriors should decrease defender HP!");
        }
    }
}
