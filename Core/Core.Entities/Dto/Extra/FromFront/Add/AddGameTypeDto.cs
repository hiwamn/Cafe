using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddGameTypeDto
    {
        public string Name { get; set; }
        public int PricePerFirstHour { get; set; }
        public int PricePerOtherhour { get; set; }
    }
    public class EditGameTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PricePerFirstHour { get; set; }
        public int PricePerOtherhour { get; set; }
    }
}
