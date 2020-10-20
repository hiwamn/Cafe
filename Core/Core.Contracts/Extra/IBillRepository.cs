using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IBillRepository : IRepository<Bill>
    {
        GetBillsByPageResultDto GetBillsByPage(BaseByUserPageBillDto dto);
        BillDto GetBillById(BaseByIdDto dto);
        GetOrdersByPageResultDto GetOrdersByPage(GetOrdersByPageDto dto);
        Bill GetByUserAndTable(AddProductToTableDto dto);
        Bill GetByTable(Guid tableId);
        List<Bill> GetLastYear(long lastYear);
        int GetAlreadyBought(Guid? userId);
        GetUserGamesByPageResultDto GetUserGamesByPage(GetUserGamesByPageDto dto);
        Bill GetByDetaill(Guid billId);
    }
}
