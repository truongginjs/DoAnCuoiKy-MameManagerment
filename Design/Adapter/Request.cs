using Design.Model;
using System;

namespace Design.Adapter
{
    public interface Request
    {
        Func<Transaction, long> GetFunction();
    }
}