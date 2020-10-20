using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class Transaction : UserBaseEntity
    {
        public int TransactionCategoryId { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public string Authority{ get; set; }
        public string RefId{ get; set; }
        public bool IsSuccessful{ get; set; }
        public int Amount { get; set; }
        public string Description{ get; set; }
        public Guid? BillId{ get; set; }
        public Bill Bill{ get; set; }
        public Guid? NextUserId{ get; set; }
        public User NextUser { get; set; }
        public string Json { get; set; }
        public int Type { get; set; }
    }
}
