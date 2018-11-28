using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAccount.Data;

namespace WebApiAccount.Business_Logic
{
    public class AccountTransaction
    {
        public List<Account> accounts = new List<Account>()
        {
            new Account() {Account_Number=92920131323,Customer_Name="Customer 1",Status="Active"},
            new Account() {Account_Number=89234999233,Customer_Name="Customer 2",Status="Active"},
            new Account() {Account_Number=92342009022,Customer_Name="Customer 3",Status="Active"},
            new Account() {Account_Number=89989234992,Customer_Name="Customer 4",Status="Inactive"},
            new Account() {Account_Number=23900000002,Customer_Name="Customer 5",Status="Inactive"},
            new Account() {Account_Number=49398453948,Customer_Name="Customer 6",Status="Active"}
        };
        public List<Transaction> transactions = new List<Transaction>()
        {
            new Transaction() {Transaction_ID="TX323423002",Account_Number=92920131323,Transaction_Type="Credit",Amount=10000,Remarks="Initial Deposit"},
            new Transaction() {Transaction_ID="TX234234234",Account_Number=89234999233,Transaction_Type="Credit",Amount=23560,Remarks="Initial Deposit"},
            new Transaction() {Transaction_ID="TX455611231",Account_Number=92342009022,Transaction_Type="Credit",Amount=2333,Remarks="Initial Deposit"},
            new Transaction() {Transaction_ID="TX324564542",Account_Number=89989234992,Transaction_Type="Credit",Amount=500,Remarks="Initial Deposit"},
            new Transaction() {Transaction_ID="TX223423222",Account_Number=23900000002,Transaction_Type="Credit",Amount=1000,Remarks="Initial Deposit"},
            new Transaction() {Transaction_ID="TX463463454",Account_Number=49398453948,Transaction_Type="Credit",Amount=199820,Remarks="Initial Deposit"},
            new Transaction() {Transaction_ID="TX234235233",Account_Number=89989234992,Transaction_Type="Debit",Amount=500,Remarks="ATM/929392"},
            new Transaction() {Transaction_ID="TX923989392",Account_Number=92920131323,Transaction_Type="Credit",Amount=3000,Remarks="NEFT/23322"},
            new Transaction() {Transaction_ID="TX239482938",Account_Number=49398453948,Transaction_Type="Credit",Amount=20000,Remarks="NEFT/44333"},
            new Transaction() {Transaction_ID="TX212312322",Account_Number=92920131323,Transaction_Type="Debit",Amount=1500,Remarks="ATM/30202"},
            new Transaction() {Transaction_ID="TX929828222",Account_Number=89234999233,Transaction_Type="Credit",Amount=4500,Remarks="NEFT/3322"},
            new Transaction() {Transaction_ID="TX239892282",Account_Number=23900000002,Transaction_Type="Debit",Amount=1000,Remarks="ATM/3232"},
            new Transaction() {Transaction_ID="TX239892003",Account_Number=49398453948,Transaction_Type="Debit",Amount=3000,Remarks="ATM/2342"}
        };
        /// <summary>
        /// Get account details 
        /// </summary>
        /// <returns></returns>
        public List<object> GetAllAccountDetails()
        {
            var query = from acc in accounts
                        join trans in transactions on acc.Account_Number equals trans.Account_Number
                        select new
                        {
                            Name = acc.Customer_Name,
                            AccountNumber = acc.Account_Number,
                            Stat = acc.Status,
                            Balance = (transactions.Where(w => w.Account_Number == acc.Account_Number && w.Transaction_Type == "Credit")
                                        .Sum(attr => attr.Amount) -
                                    transactions.Where(w => w.Account_Number == acc.Account_Number && w.Transaction_Type == "Debit")
                                        .Sum(attr => attr.Amount))
                        };
            return query.Distinct().ToList<object>();
        }
        /// <summary>
        /// Get active account details 
        /// </summary>
        /// <returns></returns>
        public List<object> GetActiveAccountDetails()
        {
            var query = from acc in accounts
                        join trans in transactions on acc.Account_Number equals trans.Account_Number
                        where acc.Status=="Active"
                        select new
                        {
                            Name = acc.Customer_Name,
                            AccountNumber = acc.Account_Number,
                            Balance = (transactions.Where(w => w.Account_Number == acc.Account_Number && w.Transaction_Type == "Credit")
                                        .Sum(attr => attr.Amount) -
                                    transactions.Where(w => w.Account_Number == acc.Account_Number && w.Transaction_Type == "Debit")
                                        .Sum(attr => attr.Amount))
                        };
            return query.Distinct().ToList<object>();
        }
        /// <summary>
        /// Get account details with minimum balance 10000 
        /// </summary>
        /// <returns></returns>
        public List<object> GetWithMinimumBalnce()
        {
            var query = from acc in accounts
                        join trans in transactions on acc.Account_Number equals trans.Account_Number
                        select new
                        {
                            Name = acc.Customer_Name,
                            AccountNumber = acc.Account_Number,
                            Balance = (transactions.Where(w => w.Account_Number == acc.Account_Number && w.Transaction_Type == "Credit")
                                        .Sum(attr => attr.Amount) -
                                    transactions.Where(w => w.Account_Number == acc.Account_Number && w.Transaction_Type == "Debit")
                                        .Sum(attr => attr.Amount))
                        };
            return query.Distinct().Where(x=>x.Balance>=10000).ToList<object>();
        }
        /// <summary>
        /// Get account details with balance less than or equalto 500
        /// </summary>
        /// <returns></returns>
        public List<object> GetBalanceLessThan500()
        {
            var query = from acc in accounts
                        join trans in transactions on acc.Account_Number equals trans.Account_Number
                        select new
                        {
                            Name = acc.Customer_Name,
                            AccountNumber = acc.Account_Number,
                            Balance = (transactions.Where(w => w.Account_Number == acc.Account_Number && w.Transaction_Type == "Credit")
                                        .Sum(attr => attr.Amount) -
                                    transactions.Where(w => w.Account_Number == acc.Account_Number && w.Transaction_Type == "Debit")
                                        .Sum(attr => attr.Amount))
                        };
            return query.Distinct().Where(x => x.Balance <=500).ToList<object>();
        }
    }
}
