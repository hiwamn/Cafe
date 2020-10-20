using System;

namespace Core.Entities.Dto
{
    public class BaseByUserPageDto
    {
        public int PageNo{ get; set; }
        public Guid? UserId { get; set; }
        public long To { get; set; }
        public long From { get; set; }
        public Guid? TableId { get; set; }
        public int? Type { get; set; }
    }
}
