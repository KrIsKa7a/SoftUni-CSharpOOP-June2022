namespace FightingArena.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 55;
            int expectedHp = 33;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            FieldInfo nameField = this.GetField("name");
            string actualName = (string)nameField.GetValue(warrior);

            FieldInfo damageField = this.GetField("damage");
            int actualDamage = (int)damageField.GetValue(warrior);

            FieldInfo hpField = this.GetField("hp");
            int actualHp = (int)hpField.GetValue(warrior);

            Assert.AreEqual(expectedName, actualName,
                "Constructor should initialize the Name of the Warrior!");
            Assert.AreEqual(expectedDamage, actualDamage,
                "Constructor should initialize the Damage of the Warrior!");
            Assert.AreEqual(expectedHp, actualHp,
                "Constructor should initialize the HP of the Warrior!");
        }

        [Test]
        public void TestNameGetter()
        {
            string expectedName = "Pesho";
            Warrior warrior = new Warrior(expectedName, 55, 33);

            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName,
                "Getter of the property Name should return the value of name!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("           ")]
        public void TestNameSetterValidation(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 55, 55);
            }, "Name should not be empty or whitespace!");
        }

        [Test]
        public void TestDamageGetter()
        {
            int expectedDamage = 55;
            Warrior warrior = new Warrior("Pesho", expectedDamage, 33);

            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage,
                "Getter of the property Damage should return the value of damage!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestDamageSetterValidation(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 55);
            }, "Damage value should be positive!");
        }

        [Test]
        public void TestHPGetter()
        {
            int expectedHP = 55;
            Warrior warrior = new Warrior("Pesho", 33, expectedHP);

            int actualHP = warrior.HP;

            Assert.AreEqual(expectedHP, actualHP,
                "Getter of the property HP should return the value of hp!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        public void TestHPSetterValidation(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 55, hp);
            }, "HP should not be negative!");
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowErrorWhenAttackingWarriorIsLow(int startHP)
        {
            Warrior warriorA = new Warrior("Pesho", 70, startHP);
            Warrior warriorD = new Warrior("Gosho", 55, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowErrorWhenDefendingWarriorIsLow(int startHP)
        {
            Warrior warriorA = new Warrior("Pesho", 45, 65);
            Warrior warriorD = new Warrior("Gosho", 35, startHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase(50, 60)]
        [TestCase(50, 51)]
        public void AttackShouldThrowErrorWhenDefendingWarriorIsStronger(int attackerHp, int defenderDamage)
        {
            Warrior warriorA = new Warrior("Pesho", 50, attackerHp);
            Warrior warriorD = new Warrior("Gosho", defenderDamage, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "You are trying to attack too strong enemy");
        }

        [TestCase(70, 50)]
        [TestCase(60, 55)]
        [TestCase(60, 60)]
        public void SuccessAttackShouldDecreaseAttackerHP(int attackerHp, int defenderDamage)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", 50, attackerHp);
            Warrior warriorD = new Warrior("Gosho", defenderDamage, 55);

            //Act
            warriorA.Attack(warriorD);

            int actualHp = warriorA.HP;
            int expectedHp = attackerHp - defenderDamage;

            Assert.AreEqual(expectedHp, actualHp,
                "Successful attack should decrease attacker HP!");
        }

        [TestCase(70, 40)]
        [TestCase(60, 55)]
        [TestCase(60, 59)]
        public void SucessAttackShouldKillEnemyIfMyDamageIsOverTheirHP(int attackerDamage, int defenderHp)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", attackerDamage, 100);
            Warrior warriorD = new Warrior("Gosho", 40, defenderHp);

            //Act
            warriorA.Attack(warriorD);

            int actualDefenderHp = warriorD.HP;
            int expectedDefenderHp = 0;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp,
                "Attacking enemy with lower HP than attacker Damage should leave them with zero HP!");
        }

        [TestCase(50, 100)]
        [TestCase(50, 60)]
        [TestCase(50, 51)]
        [TestCase(50, 50)]
        public void SuccessAttackShouldDecreaseEnemyHPIfWeDoNotKillThem(int attackerDamage, int defenderHp)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", attackerDamage, 100);
            Warrior warriorD = new Warrior("Gosho", 30, defenderHp);

            //Act
            warriorA.Attack(warriorD);

            int actualDefenderHp = warriorD.HP;
            int expectedDefenderHp = defenderHp - attackerDamage;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp,
                "Attacking enemy with higher HP than attacker Damage should leave them with correct HP value!");
        }

        private FieldInfo GetField(string fieldName)
            =>  typeof(Warrior)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == fieldName);
    }
}