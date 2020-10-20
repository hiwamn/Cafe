﻿using Core.Entities.Dto;

namespace Core.ApplicationServices
{
    public interface IDeleteEvent : IApplicationService
    {
        ApiResult Execute(BaseByIdDto dto);
    }
}