using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class LastDiscount : UserBaseEntity
    {
        public int Price { get; set; }
        public int BuyingValue { get; set; }
    }
}
