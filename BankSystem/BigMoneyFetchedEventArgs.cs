namespace BankSystem
{
    public class BigMoneyFetchedEventArgs
    {
        public BigMoneyFetchedEventArgs(Account acc, double amount)
        {
            Account = acc;
            Amount = amount;
        }

        public Account Account { get; set; }
        public double Amount { get; set; }
    }
}
