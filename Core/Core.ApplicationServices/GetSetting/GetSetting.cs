
using Core.Contracts;
using Core.Entities.Dto;
using System;
using System.Linq;
using System.Reflection;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetSetting : IGetSetting
    {
        private readonly IUnitOfWork unit;

        public GetSetting(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetSettingResultDto Execute()
        {
            var set = unit.Setting.GetAll();
            SettingDto res = new SettingDto { };
            
            set.ForEach(p =>
            {
                PropertyInfo propertyInfo = res.GetType().GetProperties().FirstOrDefault(q=>q.Name == p.Name);
                propertyInfo.SetValue(res, Convert.ChangeType(p.Value.ToString(), propertyInfo.PropertyType));
            });

            return new GetSettingResultDto
            {
                Status = true,
                Object = res
            };
        }
    }
}
