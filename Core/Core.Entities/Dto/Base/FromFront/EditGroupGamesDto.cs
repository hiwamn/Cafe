using System;

namespace Core.Entities.Dto
{
    public class EditGroupGameDto
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public long StartAt { get; set; }
        public int GameTypeId { get; set; }
        public string Description{ get; set; }
        public string Name{ get; set; }
    }
}
