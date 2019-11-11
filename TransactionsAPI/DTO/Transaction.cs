using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionsAPI.DTO
{
    public class Transaction
    {
        public int ToAccountNo;
        public int FromAccountNo;
        public int Type;
        public int UserId;
        public int Amount;
    }
}
