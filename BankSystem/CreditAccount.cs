using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class CreditAccount : Account
    {
        public CreditAccount(string id, string pwd, double limit)
            : base(id, pwd)
        {
            Limit = limit;
        }

        public double Limit { get; private set; }

        public override bool WithdrawMoney(double money)
        {
            if (money < 0) return false;

            if (Money + Limit >= money)
            {
                Money -= money;
                return true;
            }
            Show("Not enough credit left!");
            return false;

        }

    }

}