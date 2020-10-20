using Core.ApplicationServices;
using Core.Entities;
using Core.Entities.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EndPoint.Controllers
{

    public class ProductController : SimpleController
    {
        private readonly IGetProducts getProductCategories;
        private readonly IAddProductRate addProductRate;

        public ProductController(
            IGetProducts getProductCategories,
            IAddProductRate addProductRate
            )
        {
            this.getProductCategories = getProductCategories;
            this.addProductRate = addProductRate;
        }

        [HttpGet]
        public ActionResult<GetProductsResultDto> GetProducts([FromQuery] GetProductsDto dto)
        {
            return getProductCategories.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddProductRate([FromBody] AddProductRateDto dto)
        {
            return addProductRate.Execute(dto);
        }


    }
}
