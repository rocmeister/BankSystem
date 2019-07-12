public class BankDemo {
	public static void Main(string [] args)
	{
		Bank bank = new Bank();
        bank.OpenAccount("0", "0000", 0, 100);
        bank.OpenAccount("1", "1111", 100, 2000);
        bank.OpenAccount("2", "2222", 20);
		bank.OpenAccount("3", "3333", 50);
        ATM atm = new ATM(bank);
		
		for( int i=0; i<5; i++)
		{
			atm.Transaction();
		}
	}
	
}
