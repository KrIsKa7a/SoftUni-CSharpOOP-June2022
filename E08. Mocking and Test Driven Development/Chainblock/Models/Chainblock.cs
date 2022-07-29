namespace Chainblock.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class Chainblock : IChainblock
    {
        private readonly ICollection<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new HashSet<ITransaction>();
        }

        public int Count 
            => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException("You cannot add already existing transaction!");
            }

            this.transactions.Add(tx);
        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.Any(t => t.Id == tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction currentTransaction = this.transactions
                .FirstOrDefault(t => t.Id == id);

            if (currentTransaction == null)
            {
                throw new ArgumentException("You cannot change the status of non-existing transaction!");
            }

            currentTransaction.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transactionToRemove = this.transactions
                .FirstOrDefault(t => t.Id == id);

            if (transactionToRemove == null)
            {
                throw new InvalidOperationException("You cannot delete a transaction that do no exist in our records!");
            }

            this.transactions.Remove(transactionToRemove);
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException("Transaction with the provided id does not exist in our records!");
            }

            return this.transactions.First(t => t.Id == id);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactionsByStatus = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToArray();

            if (!transactionsByStatus.Any())
            {
                throw new InvalidOperationException(
                    "There are no transactions in our records meeting your desired transaction status!");
            }

            return transactionsByStatus;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> transactionSenders = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .Select(t => t.From)
                .ToArray();

            if (!transactionSenders.Any())
            {
                throw new InvalidOperationException(
                    "There are no transactions in our records meeting provided transaction status!");
            }

            return transactionSenders;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> transactionSenders = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .Select(t => t.To)
                .ToArray();

            if (!transactionSenders.Any())
            {
                throw new InvalidOperationException(
                    "There are no transactions in our records meeting provided transaction status!");
            }

            return transactionSenders;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToArray();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (ITransaction transaction in this.transactions)
            {
                yield return transaction;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
