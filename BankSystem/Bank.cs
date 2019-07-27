using System.Collections.Generic;

namespace BankSystem
{
    public class Bank
    {

        private List<Account> _accounts = new List<Account>();

        public Account this[string id]
        {
            get
            {
                foreach (Account account in this._accounts)
                {
                    if (account.Id == id)
                    {
                        return account;
                    }
                }
                return null;
            }
        }

        public Account OpenAccount(string id, string pwd)
        {
            Account account = new Account(id, pwd);
            _accounts.Add(account);

            return account;
        }

        // constructor for credit account
        public Account OpenAccount(string id, string pwd, double limit)
        {
            Account account = new CreditAccount(id, pwd, limit);
            _accounts.Add(account);

            return account;
        }

        public bool CloseAccount(Account account)
        {
            int idx = _accounts.IndexOf(account);
            if (idx < 0) return false;
            _accounts.Remove(account);
            return true;
        }

        public Account FindAccount(string id, string pwd)
        {
            foreach (Account account in _accounts)
            {
                if (account.IsMatch(id, pwd))
                {
                    return account;
                }
            }

            // another way of finding the account
            //for (int i = 0; i < accounts.Count; i++)
            //{
            //    Account account = accounts[i];

            //    if( account.IsMatch(id, pwd))
            //    {
            //        return account;
            //    }
            //}

            return null;
        }

    }

}
