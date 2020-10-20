
using Core.Contracts;
using Core.Entities.Dto;
using System;
using System.Linq;
using System.Reflection;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class UpdateSetting : IUpdateSetting
    {
        private readonly IUnitOfWork unit;

        public UpdateSetting(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public BaseApiResult Execute(SettingDto dto)
        {
            var set = unit.Setting.GetAll();


            set.ForEach(p =>
            {
                PropertyInfo propertyInfo = dto.GetType().GetProperties().FirstOrDefault(q => q.Name == p.Name);
                p.Value = propertyInfo.GetValue(dto).ToString();
                //propertyInfo.SetValue(res, Convert.ChangeType(p.Value.ToString(), propertyInfo.PropertyType));
            });
            unit.Complete();

            return new BaseApiResult
            {
                Status = true                
            };
        }
    }
}
