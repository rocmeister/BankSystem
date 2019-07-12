using System;
using System.Collections;
using System.Collections.Generic;

public class Bank {

	List<Account> accounts = new List<Account>();
	
	public Account OpenAccount(string id, string pwd, double money)
	{
		Account account = new Account(id, pwd, money);
		accounts.Add( account );
		
		return account;
	}
    
    // constructor for credit account
    public Account OpenAccount(string id, string pwd, double money, double limit)
    {
        Account account = new CreditAccount(id, pwd, money, limit);
        accounts.Add(account);

        return account;
    }

    public bool CloseAccount( Account account) 
	{
		int idx = accounts.IndexOf(account);
		if( idx<0 )return false;
		accounts.Remove(account);
		return true;		
	}
	
	public Account FindAccount(string id, string pwd)
	{
		foreach(Account account in accounts)
		{
			if( account.IsMatch(id, pwd))
			{
				return account;
			}
		}
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
