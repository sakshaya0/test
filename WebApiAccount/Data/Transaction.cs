using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAccount.Data
{
    public class Transaction
    {
        public string Transaction_ID { get; set; }
        public long Account_Number { get; set; }
        public string Transaction_Type { get; set; }
        public int Amount { get; set; }
        public string Remarks { get; set; }
    }
}
