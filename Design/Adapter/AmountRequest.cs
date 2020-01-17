using Design.Model;
using System;

namespace Design.Adapter
{
    public class AmountRequest : Request
    {
        private Func<Transaction, long> func = null;
        public Func<Transaction, long> GetFunction() => func;
    }
}