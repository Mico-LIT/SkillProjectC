using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Events.Example
{
    class AccountEventArgs
    {
        private double sum;
        public double Sum { get { return this.sum; } set { sum = value; } }
        public string Mess { get; set; }

        public AccountEventArgs(string mess,double sum)
        {
            this.Mess = mess;
            this.Sum = sum;
        }
    }

    class Account
    {
        private double sum;
        public delegate void AccountStateHandle(object obj, AccountEventArgs accountEventArgs);

        public event AccountStateHandle Withdrawn;
        public event AccountStateHandle Added;

        public Account(int sum)
        {
            this.sum = sum;
        }
        public void Put(double sum)
        {
            this.sum += sum;
            Added?.Invoke(this, new AccountEventArgs("На счет поступило {sum}", sum));
        }

        public void Withdraw(double sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;

                if (this.Withdrawn != null)
                {
                    Withdrawn(this,new AccountEventArgs($"Сумма {sum} снята со счета!",sum));
                }
            }
            else
            {
                if (this.Added != null)
                {
                    Withdrawn(this,new AccountEventArgs("Нехватает бабла",sum));
                }
            }
        }
    }

    class Unit_1
    {
        void Monitor(object obj, AccountEventArgs accountEventArgs)
        {
            Console.WriteLine(accountEventArgs.Mess);
        }

        public Unit_1()
        {
            Account account = new Account(500);
            account.Added +=Monitor;
            account.Withdrawn += Monitor;
            account.Put(100);
            account.Withdraw(130);
            account.Withdrawn -= Monitor;
            account.Withdraw(530);
            Console.ReadLine();
        }
    }
}
