namespace Chainblock.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    using Contracts;
    using Models;

    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction defTransaction;
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            this.defTransaction = new Transaction(1, TransactionStatus.Successful, "Pesho", "Gosho", 50);
            this.chainblock = new Chainblock();
        }

        [Test]
        public void ChainblockShouldStoreTransactionsInPrivateCollection()
        {
            Type type = typeof(Chainblock);
            FieldInfo[] privateFields = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            bool transactionsCollectionExists = privateFields
                .Any(fi => fi.FieldType == typeof(ICollection<ITransaction>));

            Assert.IsTrue(transactionsCollectionExists,
                "There must be private collection to store the transactions in the Chainblock!");
        }

        [Test]
        public void ConstructorShouldInitializeTheCollectionAndCountProperty()
        {
            Type type = typeof(Chainblock);
            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                                     f.FieldType == typeof(ICollection<ITransaction>));

            IChainblock chainblockTest = new Chainblock();

            object actualFieldValue = collectionField?.GetValue(chainblockTest);
            int actualCount = chainblockTest.Count;

            int expectedCount = 0;

            Assert.IsNotNull(actualFieldValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingTransactionShouldPhysicallyAddTheTransaction()
        {
            ITransaction transactionToAdd = 
                new Transaction(1, TransactionStatus.Successful, "Pesho", "Gosho", 50);
            this.chainblock.Add(transactionToAdd);

            Type type = typeof(Chainblock);
            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                                     f.FieldType == typeof(ICollection<ITransaction>));
            ICollection<ITransaction> actualFieldValue = (ICollection<ITransaction>)
                collectionField?.GetValue(this.chainblock);

            bool addedTransactionExists = actualFieldValue.Contains(transactionToAdd);

            Assert.IsTrue(addedTransactionExists);
        }

        [Test]
        public void AddingTransactionShouldIncreaseCount()
        {
            this.chainblock.Add(this.defTransaction);

            int actualCount = this.chainblock.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingExistingTransactionShouldThrowAnException()
        {
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.Add(this.defTransaction);
            }, "You cannot add already existing transaction!");
        }

        [Test]
        public void ContainsByTransactionShouldReturnTrueWithExistingTransaction()
        {
            this.chainblock.Add(this.defTransaction);

            bool actualResult = this.chainblock.Contains(this.defTransaction);
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void ContainsByTransactionShouldReturnFalseWithNonExistingTransaction()
        {
            ITransaction nonExistingTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "ssss", "tttt", 50);
            bool actualResult = this.chainblock.Contains(nonExistingTransaction);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void ContainsByIdShouldReturnTrueWithExistingTransaction()
        {
            this.chainblock.Add(this.defTransaction);

            bool actualResult = this.chainblock.Contains(this.defTransaction.Id);
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void ContainsByIdShouldReturnFalseWithNonExistingTransaction()
        {
            bool actualResult = this.chainblock.Contains(this.defTransaction.Id);
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeTheStatusValueWhenSuccess()
        {
            ITransaction transaction =
                new Transaction(2, TransactionStatus.Failed, "Pesho", "Gosho", 50);
            this.chainblock.Add(transaction);

            this.chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Successful);

            TransactionStatus expectedStatus = TransactionStatus.Successful;
            TransactionStatus actualStatus = transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowAnExceptionWithNonExistingTransaction()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(2, TransactionStatus.Aborted);
            }, "You cannot change the status of non-existing transaction!");
        }

        [Test]
        public void RemoveTransactionShouldPhysicallyDeleteTheTransaction()
        {
            ITransaction transactionToAdd =
                new Transaction(1, TransactionStatus.Successful, "Pesho", "Gosho", 50);
            this.chainblock.Add(transactionToAdd);
            this.chainblock.RemoveTransactionById(transactionToAdd.Id);

            Type type = typeof(Chainblock);
            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                                     f.FieldType == typeof(ICollection<ITransaction>));
            ICollection<ITransaction> actualFieldValue = (ICollection<ITransaction>)
                collectionField?.GetValue(this.chainblock);

            bool exists = actualFieldValue.Contains(transactionToAdd);
            Assert.IsFalse(exists);
        }

        [Test]
        public void RemoveTransactionShouldDecreaseCount()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Failed, "sss", "ppp", 23);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);

            this.chainblock.RemoveTransactionById(secondTransaction.Id);

            int actualCount = this.chainblock.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveTransactionShouldThrowAnExceptionWithNonExistingTransaction()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.RemoveTransactionById(555);
            }, "You cannot delete a transaction that do no exist in our records!");
        }

        [Test]
        public void GetByIdShouldReturnCorrectTransactionWithExistingId()
        {
            this.chainblock.Add(this.defTransaction);
            ITransaction defTransactionRef = 
                this.chainblock.GetById(this.defTransaction.Id);

            int expectedId = this.defTransaction.Id;
            int actualId = defTransactionRef.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void GetByIdShouldThrowAnExceptionWithNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetById(555);
            }, "Transaction with the provided id does not exist in our records!");
        }

        [Test]
        public void GetByTransactionStatusShouldReturnTransactionInCorrectOrder()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);

            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(thirdTransaction);

            ICollection<ITransaction> expected = new List<ITransaction>()
            {
                this.defTransaction,
                secondTransaction
            };
            IEnumerable<ITransaction> actual = this.chainblock.GetByTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTransactionStatusShouldReturnSingleTransactionWhenOneTransactionMeetsTheStatus()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            ICollection<ITransaction> expected = new List<ITransaction>()
            {
                thirdTransaction
            };
            IEnumerable<ITransaction> actual = this.chainblock
                .GetByTransactionStatus(TransactionStatus.Aborted);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenThereAreTransactionsAndNoOneMeetsTheStatus()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized);
            }, "There are no transactions in our records meeting your desired transaction status!");
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenThereAreNoTransactions()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized);
            }, "There are no transactions in our records meeting your desired transaction status!");
        }

        [Test]
        public void GetAllSendersByStatusShouldReturnCorrectSendersOrderedWithNoDuplication()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);

            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(thirdTransaction);

            ICollection<string> expected = new List<string>()
            {
                this.defTransaction.From,
                secondTransaction.From
            };
            IEnumerable<string> actual = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllSendersByStatusShouldReturnCorrectSendersOrderedWithDuplications()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);
            ITransaction fourthTransaction =
                new Transaction(4, TransactionStatus.Successful, secondTransaction.From, "aaa", 25);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);
            this.chainblock.Add(fourthTransaction);

            ICollection<string> expected = new List<string>()
            {
                this.defTransaction.From,
                secondTransaction.From,
                fourthTransaction.From
            };
            IEnumerable<string> actual = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllSendersByStatusShouldThrowExceptionWithNonExistingStatus()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);
            ITransaction fourthTransaction =
                new Transaction(4, TransactionStatus.Successful, secondTransaction.From, "aaa", 25);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);
            this.chainblock.Add(fourthTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized);
            }, "There are no transactions in our records meeting provided transaction status!");
        }

        [Test]
        public void GetAllReceiversByStatusShouldReturnCorrectSendersOrderedWithNoDuplication()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);

            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(thirdTransaction);

            ICollection<string> expected = new List<string>()
            {
                this.defTransaction.To,
                secondTransaction.To
            };
            IEnumerable<string> actual = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllReceiversByStatusShouldReturnCorrectSendersOrderedWithDuplications()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);
            ITransaction fourthTransaction =
                new Transaction(4, TransactionStatus.Successful, "vancho", secondTransaction.To, 25);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);
            this.chainblock.Add(fourthTransaction);

            ICollection<string> expected = new List<string>()
            {
                this.defTransaction.To,
                secondTransaction.To,
                fourthTransaction.To
            };
            IEnumerable<string> actual = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllReceiversByStatusShouldThrowExceptionWithNonExistingStatus()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);
            ITransaction fourthTransaction =
                new Transaction(4, TransactionStatus.Successful, secondTransaction.From, "aaa", 25);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);
            this.chainblock.Add(fourthTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized);
            }, "There are no transactions in our records meeting provided transaction status!");
        }

        [Test]
        public void GetAllOrderedByAmountDescThenByIdShouldReturnCorrectOrderWithMultipleElements()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "aaa", "bbb", 40);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Successful, "ccc", "ddd", 40);

            this.chainblock.Add(thirdTransaction);
            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);

            ICollection<ITransaction> expected = new List<ITransaction>()
            {
                this.defTransaction,
                secondTransaction,
                thirdTransaction
            };
            IEnumerable<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllOrderedByAmountDescThenByIdShouldReturnCorrectOrderWithSingleElement()
        {
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expected = new List<ITransaction>()
            {
                this.defTransaction
            };
            IEnumerable<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expected, actual);
        }

        //TODO: Continue TDD

        [Test]
        public void ChainblockShouldBeIterable()
        {
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successful, "sss", "rrr", 30);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Aborted, "aaa", "aaa", 15);
            ITransaction fourthTransaction =
                new Transaction(4, TransactionStatus.Successful, "Mimi", "aaa", 25);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);
            this.chainblock.Add(fourthTransaction);

            ICollection<ITransaction> actualIteration = new List<ITransaction>();
            foreach (ITransaction transaction in this.chainblock)
            {
                actualIteration.Add(transaction);
            }

            ICollection<ITransaction> expectedIteration = new List<ITransaction>()
            {
                this.defTransaction,
                secondTransaction,
                thirdTransaction,
                fourthTransaction
            };

            CollectionAssert.AreEqual(expectedIteration, actualIteration);
        }
    }
}
