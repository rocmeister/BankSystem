using System;
using System.Collections;

namespace BankSystem
{
    public class ATM
    {
        // declare the event delegation
        public delegate void BigMoneyFetchedEventHandler(object sender, BigMoneyFetchedEventArgs args);

        // declare the event variable
        public event BigMoneyFetchedEventHandler BigMoneyFetched;

        private Bank bank;
        public ATM(Bank bank)
        {
            this.bank = bank;
        }

        public void Transaction()
        {
            Show("please insert your card");
            string id = GetInput();

            Show("please enter your password");
            string pwd = GetInput();

            Account account = bank.FindAccount(id, pwd);

            if (account == null)
            {
                Show("card invalid or password not corrent");
                return;
            }

            string op = "";
            while (op != "4")
            {
                Show("1: display; 2: save; 3: withdraw; 4: exit");
                op = GetInput();
                string smoney;
                double money;
                bool ok;

                switch(op)
                {
                    case "1":
                        ShowAccountInfo(account);
                        break;
                    case "2":
                        Show("save money");
                        smoney = GetInput();
                        money = double.Parse(smoney);

                        ok = account.SaveMoney(money);
                        if (ok) ShowAccountInfo(account);
                        else Show("eeer");

                        //Show("balance: " + account.Money);
                        //ShowAccountInfo(account);
                        break;
                    case "3":
                        Show("withdraw money");
                        smoney = GetInput();
                        money = double.Parse(smoney);

                        ok = account.WithdrawMoney(money);
                        //if (ok) Show("ok");
                        //else Show("eeer");

                        if (ok)
                        {
                            ShowAccountInfo(account);
                            // handle a warning event
                            if (money > 10000 && BigMoneyFetched != null)
                            {
                                BigMoneyFetched(this, new BigMoneyFetchedEventArgs(account, money));
                            }
                        } else
                        {
                            Show("eeer");
                        }

                        Random rnd = new Random();
                        if (new Random().Next(3) < 1)
                        {
                            throw new BadCashException("Received bad cash!");
                        }

                        break;
                    case "4":
                        break;
                    default:
                        Show("Invalid option");
                        break;
                }

                //if (op == "1")
                //{
                //    ShowAccountInfo(account);
                //}
                //else if (op == "2")
                //{
                //    Show("save money");
                //    string smoney = GetInput();
                //    double money = double.Parse(smoney);

                //    bool ok = account.SaveMoney(money);
                //    if (ok) Show("ok");
                //    else Show("eeer");

                //    //Show("balance: " + account.Money);
                //    ShowAccountInfo(account);
                //}
                //else if (op == "3")
                //{
                //    Show("withdraw money");
                //    string smoney = GetInput();
                //    double money = double.Parse(smoney);

                //    bool ok = account.WithdrawMoney(money);
                //    if (ok) Show("ok");
                //    else Show("eeer");

                //    //Show("balance: " + account.Money);
                //    ShowAccountInfo(account);

                //    // handle a warning event
                //    if (money > 10000 && BigMoneyFetched != null)
                //    {
                //        BigMoneyFetched(this, new BigMoneyFetchedEventArgs(account, money));
                //    }
                //}
                //else
                //{
                //    Show("Invalid option");
                //}
            }
            
        }

        private void ShowAccountInfo(Account account)
        {
            if (account is CreditAccount)
            {
                if (account.Money >= 0) //{ Show("balance: " + account.Money); }
                {
                    Console.WriteLine("balance: {0}, credit limit: {1}", 
                        account.Money, ((CreditAccount)account).Limit);
                    //Show("balance: {0}, credit limit: {1}", account.Money);
                }
                else
                {
                    //Show("in debt: " + -account.Money);
                    Console.WriteLine("in debt: {0}, credit limit: {1}",
                        -account.Money, ((CreditAccount)account).Limit);
                }
            }
            else
            {
                Show("balance: " + account.Money);
            }
        }

        public void Show(string msg)
        {
            Console.WriteLine(msg);
        }
        public string GetInput()
        {
            return Console.ReadLine();// ÊäÈë×Ö·û
        }
    }

}