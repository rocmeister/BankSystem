using System;

namespace BankSystem
{
    public class BankDemo
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            
            // two credit card accounts
            bank.OpenAccount("0", "0000", 100);
            bank.OpenAccount("1", "1111", 20000);
            
            // two savings card accounts
            bank.OpenAccount("2", "2222");
            bank.OpenAccount("3", "3333");

            // make use of the Bank array type
            bank["0"].SaveMoney(20);
            bank["2"].SaveMoney(1000);

            ATM atm = new ATM(bank);
            atm.BigMoneyFetched += ShowBigMoneyWarning; // register an event

            while(true)
            {
                try
                {
                    atm.Transaction();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                }
            }
            Console.ReadLine();
        }

        static void ShowBigMoneyWarning(object sender, BigMoneyFetchedEventArgs args)
        {
            Console.WriteLine("Warning: ID {0} just withdrew {1}! ", args.Account.Id, 
                args.Amount);
        }

    }
}
