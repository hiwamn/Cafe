using Core.Entities.Dto;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetSlidersResultDto : BaseApiResult
    {
        public List<SliderDto> Object{ get;  set; }
    }
}