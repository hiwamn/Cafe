using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class TransactionCategory
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public List<Transaction> Transaction { get; set; }

    }
}
