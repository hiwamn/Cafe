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
    
    public class UpdateController : SimpleController
    {
        private readonly ICheckUpdate checkUpdate;

        public UpdateController(ICheckUpdate checkUpdate)
        {
            this.checkUpdate = checkUpdate;
        }

        [HttpGet]
        
        public ActionResult<UpdateDto> CheckUpdate([FromQuery]string Version)
        {
            return checkUpdate.Execute(Version);
        }
        

    }
}
