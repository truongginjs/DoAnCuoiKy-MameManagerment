using Design.Model;
using System;

namespace Design.Adapter
{
    public class PaymentRequest : Request
    {
        private Func<Transaction, long> func = value => value.paymentAmount;
        public Func<Transaction, long> GetFunction() => func;
        
    }
}