using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddGameToTableDto
    {
        public int GameTypeId { get; set; }
        public int Count{ get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
        public int Type { get; set; }
    }

    public class AddGameToTableResultDto : BaseApiResult
    {
        public TableDto Object { get; set; }
    }

}
