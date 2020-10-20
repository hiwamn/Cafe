using System;

namespace Core.Entities.Dto
{
    public class EditProfileDto
    {
        public Guid UserId { get; set; }
        public Guid? ImageId { get; set; }
        public string Name{ get; set; }
        public string FamilyName{ get; set; }
        public long? BirthDay { get; set; }
        public int? Gender { get; set; }
        public string Bio { get; set; }
        public string NationalCode { get; set; }
    }
}
