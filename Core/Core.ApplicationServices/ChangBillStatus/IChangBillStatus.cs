using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IChangBillStatus : IApplicationService
    {
        BaseApiResult Execute(ChangBillStatusDto dto);
    }
}
