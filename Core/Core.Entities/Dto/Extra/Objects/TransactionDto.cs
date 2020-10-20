
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Price { get; set; }
        public string RefId { get; set; }
        public string Authority { get; set; }
        public string Description { get; set; }
        public bool IsSuccessful { get; set; }
        public TransactionCategoryDto TransactionCategory { get; set; }
        public UserShortDto NextUser { get; internal set; }
        public long CreatedAt { get; internal set; }
        public BillDto Bill { get; internal set; }
    }

   
}
