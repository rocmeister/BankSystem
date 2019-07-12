
using System;

public class Account
{
    // No need to add fields since we use properties
    //private double money; //decimal money;
    //private string id;
    //private string pwd;
    //string name;

    public Account(string id, string pwd, double money)
    {
        //if( money < 0 ) throw new Exception("....");
        Id = id;
        Pwd = pwd;
        Money = money;
    }

    //public double Money { get; set; }
    public double Money { get; protected set; }
    public string Id {get; } // id cannot be reset once established
    public string Pwd { get; set; }

    virtual public bool SaveMoney(double money)
    {
        if (money < 0) return false;  // Sanity check

        Money += money;
        return true;
    }

    virtual public bool WithdrawMoney(double money)
    {
        if (money < 0) return false; // Sanity check
        
        if (Money >= money)
        {
            Money -= money;
            return true;
        }

        return false;

    }

    public bool IsMatch(string id, string pwd)
    {
        return id == Id && pwd == Pwd;
    }

    public void Show(string msg)
    {
        Console.WriteLine(msg);
    }

    // other more tedious ways to write property getters and setters
    //public double Money
    //{
    //    get { return money; }
    //    set { money = value; }
    //}

    //public double getMoney()
    //{
    //	return money;
    //}

    //public void setMoney(double val)
    //{
    //	this.money = val;
    //}

    //public string getId()
    //{
    //	return id;
    //}

    //public void setId(string id)
    //{
    //	this.id = id;
    //}

    //public string getpwd()
    //{
    //	return pwd;
    //}

    //public void setPwd(string pwd)
    //{
    //	this.pwd = pwd;
    //}

}

public class CreditAccount : Account
{
    public CreditAccount(string id, string pwd, double money, double limit)
        :base(id, pwd, money)
    {
        Limit = limit;
        RemainingLimit = limit;
    }

    public double Limit { get; private set; }

    public double RemainingLimit { get; private set; }

    public override bool WithdrawMoney(double money)
    {
        if (money < 0) return false;

        if (Money + RemainingLimit >= money)
        {
            if (Money >= money)
            {
                Money -= money;
            }
            else
            {
                RemainingLimit -= money - Money;
                Money = 0;
            }
            return true;
        }
        Show("Not enough credit left!");
        return false;

    }

    public override bool SaveMoney(double money)
    {
        if (money < 0) return false;  // Sanity check

        if (RemainingLimit < Limit)
        {
            double diff = Limit - RemainingLimit;
            if (money <= diff)
            {
                RemainingLimit += money;
            }
            else
            {
                Money = money - diff;
                RemainingLimit = Limit;
            }

        }
        else
        {
            Money += money;
        }
        return true;
    }

}