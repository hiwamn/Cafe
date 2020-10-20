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

    public class GroupGameController : SimpleController
    {
        private readonly IGetGroupGamesByPage getGroupGamesByPage;
        private readonly IGetGroupGameById getGroupGameById;
        private readonly IAddGroupGame addGroupGame;
        private readonly IJoinGroupGame joinGroupGame;
        private readonly ILeftGroupGame leftGroupGame;
        private readonly IEditGroupGame editGroupGame;
        private readonly IDeleteGroupGame deleteGroupGame;

        public GroupGameController(
            IGetGroupGamesByPage getGroupGamesByPage,
            IGetGroupGameById getGroupGameById,
            IAddGroupGame addGroupGame,
            IJoinGroupGame joinGroupGame,
            ILeftGroupGame leftGroupGame,
            IEditGroupGame editGroupGame,
            IDeleteGroupGame deleteGroupGame
            )
        {
            this.getGroupGamesByPage = getGroupGamesByPage;
            this.getGroupGameById = getGroupGameById;
            this.addGroupGame = addGroupGame;
            this.joinGroupGame = joinGroupGame;
            this.leftGroupGame = leftGroupGame;
            this.editGroupGame = editGroupGame;
            this.deleteGroupGame = deleteGroupGame;
        }

        [HttpGet]
        public ActionResult<GetGroupGamesByPageResultDto> GetGroupGamesByPage([FromQuery] BaseByUserPageDto dto)
        {
            return getGroupGamesByPage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetGroupGameByIdResultDto> GetGroupGameBy([FromQuery] BaseByIdDto dto)
        {
            return getGroupGameById.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddGroupGame([FromBody] AddGroupGameDto dto)
        {
            return addGroupGame.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> JoinGroupGame([FromBody] JoinGroupGameDto dto)
        {
            return joinGroupGame.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> LeftGroupGame([FromBody] LeftGroupGameDto dto)
        {
            return leftGroupGame.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> EditGroupGame([FromBody] EditGroupGameDto dto)
        {
            return editGroupGame.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> DeleteGroupGame([FromBody] BaseByIdDto dto)
        {
            return deleteGroupGame.Execute(dto);
        }


    }
}
