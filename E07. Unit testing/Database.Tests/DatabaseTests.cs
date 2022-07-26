namespace Database.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            //This will be run before every test
            this.db = new Database();
        }

        //Valid functionality of the ctor
        //1 -> edge case (no data); 2,3 -> Valid data (success), 4 -> edge case (max data)
        //This test is meant to test the constructor and nothing more! Single responsibility!
        //I assume the Fetch() method and the Count getter to be working fine
        [TestCase(new int[] {})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void ConstructorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //Arrange
            Database testDb = new Database(elementsToAdd);

            //Act
            int[] actualData = testDb.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData,
                "Database constructor should initialize data field correctly!");
            Assert.AreEqual(expectedCount, actualCount, 
                "Constructor should set initial value for count field!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void ConstructorMustNotAllowToExceedMaximumCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);
            }, "Array's capacity must be exactly 16 integers!");
        }

        //Valid functionality of count
        //I assume that the ctor is working fine (I tested it!)
        [Test]
        public void CountMustReturnActualCount()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return the count of the added elements!");
        }

        [Test]
        public void CountMustReturnZeroWhenNoElements()
        {
            int actualCount = this.db.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should be zero when there are no elements in the Database!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //Act
            foreach (int el in elementsToAdd)
            {
                this.db.Add(el);
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, 
                "Add should physically add the elements to the field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Add should change the elements count when adding!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingMoreThan16Elements()
        {
            //Act
            for (int i = 1; i <= 16; i++)
            {
                this.db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] {1, 2, 3, 4, 5})]
        [TestCase(new int[] { 1 })]
        public void RemoveShouldRemoveTheLastElementSuccessfullyOnce(int[] startElements)
        {
            //Act
            foreach (int el in startElements)
            {
                this.db.Add(el);
            }

            this.db.Remove();
            List<int> elList = new List<int>(startElements);
            elList.RemoveAt(elList.Count - 1);

            int[] actualData = this.db.Fetch();
            int[] expectedData = elList.ToArray();

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should physically remove the element in the data field!");
            Assert.AreEqual(expectedCount, actualCount, 
                "Remove should decrement the count of the Database!");
        }

        [Test]
        public void RemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            List<int> initData = new List<int>() { 1, 2, 3 };
            foreach (int el in initData)
            {
                this.db.Add(el);
            }

            for (int i = 0; i < initData.Count; i++)
            {
                this.db.Remove();
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = this.db.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should physically remove the element in the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Remove should decrement the count of the Database!");
        }

        [Test]
        public void RemoveShouldThrowErrorWhenThereAreNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyArray(int[] initData)
        {
            //Act
            foreach (int el in initData)
            {
                this.db.Add(el);
            }

            int[] actualResult = this.db.Fetch();
            int[] expectedResult = initData;

            CollectionAssert.AreEqual(expectedResult, actualResult,
                "Fetch should return copy of the existing data!");
        }
    }
}
