using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.GlobalSettings
{
    public class AdminSettings
    {
        public static string BlockCount { get; set; }
        public static string Root { get; set; }
        public static string CustomerApi { get; set; }
        public static string StaffApi { get; set; }

        public static int Block => BlockCount.ToInt();
    }
}
