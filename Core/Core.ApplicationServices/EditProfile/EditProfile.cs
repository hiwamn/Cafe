using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class EditProfile : IEditProfile
    {
        private readonly IUnitOfWork unit;


        public EditProfile(IUnitOfWork unit)
        {
            this.unit = unit;

        }

        public BaseApiResult Execute(EditProfileDto dto)
        {
            BaseApiResult Result = new BaseApiResult { Message = Messages.OK, Status = true };
            var user = unit.Users.Get(dto.UserId);
            user.ProfileImageId = dto.ImageId;

            if (dto.Name != null && dto.Name != "")
                user.Name = dto.Name; 
            if (dto.FamilyName != null && dto.FamilyName!= "")
                user.FamilyName = dto.FamilyName;
            if (dto.BirthDay!= null)
                user.Birthday = dto.BirthDay;
            if (dto.Gender!= null)
                user.Gender = dto.Gender;
            if (dto.Bio != null && dto.Bio != "")
                user.Bio = dto.Bio;
            unit.Complete();
            return Result;
        }
    }
}
