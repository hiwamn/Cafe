using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetUserById : IGetUserById
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public GetUserById(IUnitOfWork unit,IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }

        public GetUserByIdResultDto Execute(GetUserByIdDto dto)
        {
            var user = unit.Users.GetUserById(dto);
            user.Object.Token = jwtHandler.Create(user.Object.Id);
            return user;            
        }
    }

    
}
