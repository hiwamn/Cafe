using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddTransactionDto
    {
        public Guid UserId { get; set; }
        public int Price { get; set; }
        public string RefId { get; set; }
        public string Authority { get; set; }
        public string Description { get; set; }
        public bool IsSuccessful { get; set; }
        public int TransactionCategoryId { get; set; }
    }
}
