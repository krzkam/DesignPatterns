﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Memento
{
    //Memento

    //public class Memento
    //{
    //    public int Balance { get; }

    //    public Memento(int balance)
    //    {
    //        Balance = balance;
    //    }
    //}

    //public class BankAccount
    //{
    //    private int balance;

    //    public BankAccount(int balance)
    //    {
    //        this.balance = balance;
    //    }

    //    public Memento Deposit(int amount)
    //    {
    //        balance += amount;
    //        return new Memento(balance);
    //    }

    //    public void Restore(Memento m)
    //    {
    //        balance = m.Balance;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{nameof(balance)}: {balance}";
    //    }
    //}

    //Undo and Redo

    public class Memento
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            Balance = balance;
        }


    }

    public class BankAccount
    {
        private int balance;
        private List<Memento> changes = new List<Memento>();
        private int current;

        public BankAccount(int balance)
        {
            this.balance = balance;
            changes.Add(new Memento(balance));
        }

        public Memento Deposit(int amount)
        {
            balance += amount;
            var m = new Memento(balance);
            changes.Add(m);
            ++current;
            return m;
        }

        public Memento Restore(Memento m)
        {
            if (m != null)
            {
                balance = m.Balance;
                changes.Add(m);
                return m;
            }
            return null;
        }

        public Memento Undo()
        {
            if (current > 0)
            {
                var m = changes[--current];
                balance = m.Balance;
                return m;
            }
            return null;
        }

        public Memento Redo()
        {
            if (current + 1 < changes.Count)
            {
                var m = changes[++current];
                balance = m.Balance;
                return m;
            }
            return null;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }
}
