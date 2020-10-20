using System;

namespace Core.Entities.Dto
{
    public class BaseByIdDto
    {
        public Guid Id { get; set; }
    }
    public class BaseByIntIdDto
    {
        public int Id { get; set; }
    }
    public class FixedIntDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FixedGuidDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
