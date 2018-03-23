using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Delegats.Example
{
    class Account
    {
        public delegate void AccountStateHandler(string message);
        AccountStateHandler del;

        double sum;
        public double CurrentSum { get { return this.sum; } }

        public Account(int sum)
        {
            this.sum = sum;
        }
        public void Put(double sum)
        {
            this.sum += sum;
        }

        public void Withdraw(double sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;

                if (this.del != null)
                {
                    del($"Сумма {sum} снята со счета!");
                }
            }
            else
            {
                if (this.del!=null)
                {
                    del("Нехватает бабла");
                }
            }
        }

        /// <summary>
        /// Уведомить об этом клиента
        /// </summary>
        /// <param name="del"></param>
        public void RegisterHandler(AccountStateHandler del)
        {
            this.del = del;
        }

    }
    class Unit_1
    {
        void Monitor(string s)
        {
            Console.WriteLine(s);
        }

        public Unit_1()
        {
            Account account = new Account(500);
            account.RegisterHandler(Monitor);
            account.Put(100);
            account.Withdraw(130);
            account.Withdraw(530);
            Console.ReadLine();
        }
    }
}
