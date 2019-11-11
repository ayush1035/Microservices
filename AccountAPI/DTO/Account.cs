using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.DTO
{
    public class Account
    {
        public int AccNo;
        public int UserId;
        public int Balance;
        public int PhoneNo;
        public bool IsChequeBookIssued;
        public bool IsChequeBookBlocked;
        public bool IsAccountActive;
        public int BranchID;
        public string BranchName;
        
    }
}
