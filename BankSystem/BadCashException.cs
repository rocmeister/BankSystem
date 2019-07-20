using System;

namespace BankSystem
{
    public class BadCashException: Exception
    {
        public BadCashException(string message)
            : base(message)
        { }
    }
}
