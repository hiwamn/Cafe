using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class EditTableBillDto
    {
        public Guid TableId { get; set; }
        public int PeopleCount{ get; set; }
        public string Description{ get; set; }
    }
    public class EditTableBillResultDto : BaseApiResult
    {
    }



}
