using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class SearchPeople : ISearchPeople
    {
        private readonly IUnitOfWork unit;

        public SearchPeople(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public SearchPeopleResultDto Execute(SearchPeopleDto dto)
        {
            List<UserShortDto> users = unit.Users.SearchPeople(dto);
            return new SearchPeopleResultDto
            {
                Object = users,
                Status = true                
            };
        }
    }

    
}
