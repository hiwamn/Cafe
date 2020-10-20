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
        private readonly IDisableProduct disableProduct;
        private readonly IChangeProductStatus changeProductStatus;

        public ProductController(
            IGetProducts getProductCategories,
            IAddProductRate addProductRate,
            IDisableProduct disableProduct
            )
        {
            this.getProductCategories = getProductCategories;
            this.addProductRate = addProductRate;
            this.disableProduct = disableProduct;
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
        [HttpPost]
        public ActionResult<BaseApiResult> ChangeProductStatus([FromBody] ChangeProductStatusDto dto)
        {
            return changeProductStatus.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> DisableProduct([FromBody] DisableProductDto dto)
        {
            return disableProduct.Execute(dto);
        }

    }
}
