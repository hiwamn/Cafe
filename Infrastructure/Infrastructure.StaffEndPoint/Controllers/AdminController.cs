using Core.ApplicationServices;
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
    public class AdminController : SimpleController
    {
        private readonly IGetUsersByPage getUsersByPage;
        private readonly IChangeUserStatus changeUserStatus;
        private readonly IGetDashboard getDashboard;
        private readonly IAdminLogin adminLogin;
        private readonly ISendNotification sendNotification;
        private readonly IAddBarginCampaign addBarginCampaign;
        private readonly IAddGameType addGameType;
        private readonly IDeleteGameType deleteGameType;
        private readonly IEditGameType editGameType;
        private readonly IDeleteBarginCampaign deleteBarginCampaign;
        private readonly IGetGameTypes getGameTypes;
        private readonly IGetBarginTypes getBarginTypes;
        private readonly IGetOrdersByPage getOrdersByPage;
        private readonly IGetTables getTables;
        private readonly IAddSlider addSlider;
        private readonly IEditSlider editSlider;
        private readonly IDeleteSlider deleteSlider;
        private readonly IAddTable addTable;
        private readonly IDeleteTable deleteTable;
        private readonly IEditTable editTable;
        private readonly IAddProduct addProduct;
        private readonly IEditProduct editProduct;
        private readonly IDeleteProduct deleteProduct;
        private readonly IGetProductRatesByPage getProductRatesByPage;
        private readonly IChangeProductRateStatus changeProductRateStatus;
        private readonly IGetAdminProducts getAdminProducts;
        private readonly IGetUserActivity getUserActivity;
        private readonly IPaySalary paySalary;
        private readonly IGiveDiscount giveDiscount;
        private readonly IGetUsersTimeByPage getUsersTimeByPage;

        public AdminController(
            IGetUsersByPage getUsersByPage,
            IChangeUserStatus changeUserStatus,
            IGetDashboard getDashboard,
            IAdminLogin adminLogin,
            ISendNotification sendNotification,
            IAddBarginCampaign addBarginCampaign,
            IAddGameType addGameType,
            IDeleteGameType deleteGameType,
            IEditGameType editGameType,
            IDeleteBarginCampaign deleteBarginCampaign,
            IGetGameTypes getGameTypes,
            IGetBarginTypes getBarginTypes,
            IGetOrdersByPage getOrdersByPage,
            IGetTables getTables,
            IAddSlider addSlider,
            IEditSlider editSlider,
            IDeleteSlider deleteSlider,
            IAddTable addTable,
            IDeleteTable deleteTable,
            IEditTable editTable,
            IAddProduct addProduct,
            IEditProduct editProduct,
            IDeleteProduct deleteProduct,
            IGetProductRatesByPage getProductRatesByPage,
            IChangeProductRateStatus changeProductRateStatus,
            IGetAdminProducts getAdminProducts,
            IGetUserActivity getUserActivity,
            IPaySalary paySalary,
            IGiveDiscount giveDiscount,
            IGetUsersTimeByPage getUsersTimeByPage
            )
        {
            this.getUsersByPage = getUsersByPage;
            this.changeUserStatus = changeUserStatus;
            this.getDashboard = getDashboard;
            this.adminLogin = adminLogin;
            this.sendNotification = sendNotification;
            this.addBarginCampaign = addBarginCampaign;
            this.addGameType = addGameType;
            this.deleteGameType = deleteGameType;
            this.editGameType = editGameType;
            this.deleteBarginCampaign = deleteBarginCampaign;
            this.getGameTypes = getGameTypes;
            this.getBarginTypes = getBarginTypes;
            this.getOrdersByPage = getOrdersByPage;
            this.getTables = getTables;
            this.addSlider = addSlider;
            this.editSlider = editSlider;
            this.deleteSlider = deleteSlider;
            this.addTable = addTable;
            this.deleteTable = deleteTable;
            this.editTable = editTable;
            this.addProduct = addProduct;
            this.editProduct = editProduct;
            this.deleteProduct = deleteProduct;
            this.getProductRatesByPage = getProductRatesByPage;
            this.changeProductRateStatus = changeProductRateStatus;
            this.getAdminProducts = getAdminProducts;
            this.getUserActivity = getUserActivity;
            this.paySalary = paySalary;
            this.giveDiscount = giveDiscount;
            this.getUsersTimeByPage = getUsersTimeByPage;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResultDto>> Login([FromBody] LoginDto dto)
        {
            return adminLogin.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> ChangeUserStatus([FromBody] ChangeUserStatusDto dto)
        {
            return changeUserStatus.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetUsersByPageResultDto> GetUsersByPage([FromQuery] GetUsersByPageDto dto)
        {
            return getUsersByPage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetDashboardResultDto> GetDashboard([FromQuery] GetDashboardDto dto)
        {
            return getDashboard.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> SendNotification([FromBody] SendNotificationDto dto)
        {
            return sendNotification.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddBarginCampaign([FromBody] AddBarginCampaignDto dto)
        {
            return addBarginCampaign.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddGameType([FromBody] AddGameTypeDto dto)
        {
            return addGameType.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> DeleteGameType([FromBody] BaseByIntIdDto dto)
        {
            return deleteGameType.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> EditGameType([FromBody] EditGameTypeDto dto)
        {
            return editGameType.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> DeleteBarginCampaign([FromBody] BaseByIdDto dto)
        {
            return deleteBarginCampaign.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetGameTypesResultDto> GetGameTypes()
        {
            return getGameTypes.Execute();
        }
        [HttpGet]
        public ActionResult<FixedIntResultDto> GetBarginTypes()
        {
            return getBarginTypes.Execute();
        }
        [HttpGet]
        public ActionResult<GetOrdersByPageResultDto> GetOrdersByPage([FromQuery] GetOrdersByPageDto dto)
        {
            return getOrdersByPage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetTablesResultDto> GetTables()
        {
            return getTables.Execute();
        }
        [HttpPost]
        public ActionResult<ApiResult> AddSlider([FromBody] AddSliderDto dto)
        {
            return addSlider.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> EditSlider([FromBody] EditSliderDto dto)
        {
            return editSlider.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> DeleteSlider([FromBody] BaseByIdDto dto)
        {
            return deleteSlider.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddTable([FromBody] AddTableDto dto)
        {
            return addTable.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> EditTable([FromBody] EditTableDto dto)
        {
            return editTable.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> DeleteTable([FromBody] BaseByIdDto dto)
        {
            return deleteTable.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddProduct([FromBody] AddProductDto dto)
        {
            return addProduct.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> EditProduct([FromBody] EditProductDto dto)
        {
            return editProduct.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> DeleteProduct([FromBody] BaseByIdDto dto)
        {
            return deleteProduct.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetProductRatesByPageResultDto> GetProductRatesByPage([FromQuery] GetProductRatesByPageDto dto)
        {
            return getProductRatesByPage.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> ChangeProductRateStatus([FromBody] ChangeProductRateStatusDto dto)
        {
            return changeProductRateStatus.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetAdminProductsResultDto> GetAdminProducts([FromQuery] GetProductsDto dto)
        {
            return getAdminProducts.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetUserActivityResultDto> GetUserActivity([FromQuery] GetUserActivityDto dto)
        {
            return getUserActivity.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> PaySalary([FromBody] PaySalaryDto dto)
        {
            return paySalary.Execute(dto);
        }
        [HttpPost]
        public ActionResult<BaseApiResult> GiveDiscount([FromBody] GiveDiscountDto dto)
        {
            return giveDiscount.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetUsersTimeByPageResultDto> GetUsersTimeByPage([FromQuery] GetUsersTimeByPageDto dto)
        {
            return getUsersTimeByPage.Execute(dto);
        }
    }
}
