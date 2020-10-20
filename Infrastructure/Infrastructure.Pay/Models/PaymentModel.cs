using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay.Models
{
    public class PaymentModel
    {
        public int Amount { get;  set; }
        public int Type{ get; set; }
        public string Json { get; set; }
        public Guid UserId{ get;  set; }
        public string Mobile { get;  set; }
        public string NationalCode { get;  set; }
        public bool IsWeb { get;  set; }
        
        public string Message { get; set; }
    }
}
