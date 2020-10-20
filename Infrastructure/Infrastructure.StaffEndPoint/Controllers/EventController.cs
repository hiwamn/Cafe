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

    public class EventController : SimpleController
    {
        private readonly IGetEventsByPage getEventsByPage;
        private readonly IGetEventById getEventById;
        private readonly IAddEventAndLeague addEventAndLeague;
        private readonly IJoinEvent joinEvent;
        private readonly ILeftEvent leftEvent;
        private readonly IEditEvent editEvent;
        private readonly IDeleteEvent deleteEvent;

        public EventController(
            IGetEventsByPage getEventsByPage,
            IGetEventById getEventById,
            IAddEventAndLeague addEventAndLeague,
            IJoinEvent joinEvent,
            ILeftEvent leftEvent,
            IEditEvent editEvent,
            IDeleteEvent deleteEvent
            )
        {
            this.getEventsByPage = getEventsByPage;
            this.getEventById = getEventById;
            this.addEventAndLeague = addEventAndLeague;
            this.joinEvent = joinEvent;
            this.leftEvent = leftEvent;
            this.editEvent = editEvent;
            this.deleteEvent = deleteEvent;
        }

        [HttpGet]
        public ActionResult<GetEventsByPageResultDto> GetEventsByPage([FromQuery] BaseByUserPageDto dto)
        {
            return getEventsByPage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetEventByIdResultDto> GetEventById([FromQuery] BaseByIdDto dto)
        {
            return getEventById.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> AddEvent([FromBody] AddEventAndLeagueDto dto)
        {
            return addEventAndLeague.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> JoinEvent([FromBody] JoinEventDto dto)
        {
            return joinEvent.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> LeftEvent([FromBody] LeftEventDto dto)
        {
            return leftEvent.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> EditEvent([FromBody] EditEventDto dto)
        {
            return editEvent.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ApiResult> DeleteEvent([FromBody] BaseByIdDto dto)
        {
            return deleteEvent.Execute(dto);
        }


    }
}
