using System;
using System.Collections;

public class ATM {
	
	private Bank bank;
	public ATM( Bank bank)
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
		
		if( account == null)
		{
			Show("card invalid or password not corrent");
			return;
		}

		Show("1: display; 2: save; 3: withdraw");
		string op = GetInput();
        if (op == "1")
        {
            ShowAccountInfo(account);
        }
		else if( op=="2")
		{
			Show("save money");
			string smoney = GetInput();
			double money = double.Parse(smoney);
			
			bool ok = account.SaveMoney(money);
			if( ok ) Show("ok");
			else Show("eeer");

            //Show("balance: " + account.Money);
            ShowAccountInfo(account);
        }
		else if( op=="3" )
        {
			Show("withdraw money");
			string smoney = GetInput();
			double money = double.Parse(smoney);
			
			bool ok = account.WithdrawMoney(money);
			if( ok ) Show("ok");
			else Show("eeer");

            //Show("balance: " + account.Money);
            ShowAccountInfo(account);
        }
        else
        {
            Show("Invalid option");
        }
	}
	
	private void ShowAccountInfo(Account account)
    {
        if (account is CreditAccount)
        {
            Show("balance: " + account.Money);
            Show("remaining credit: " + ((CreditAccount)account).RemainingLimit);
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
