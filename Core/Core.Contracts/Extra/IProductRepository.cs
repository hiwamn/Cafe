using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        List<ProductDto> GetProducts(GetProductsDto dto);
        List<AdminProductDto> GetAdminProducts(GetProductsDto dto);
    }
}
