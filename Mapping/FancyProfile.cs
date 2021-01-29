using AutofacAndAutomapper.Models;

namespace AutofacAndAutomapper.Mapping
{
    public class FancyProfile : AutoMapper.Profile
    {
        public FancyProfile()
        {
            CreateMap<SourceType, TargetType>().ConvertUsing<SourceToTargetTypeConverter>();
        }
    }
}