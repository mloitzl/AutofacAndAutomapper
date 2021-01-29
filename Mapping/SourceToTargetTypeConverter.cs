using AutofacAndAutomapper.Models;
using AutofacAndAutomapper.Services;
using AutoMapper;

namespace AutofacAndAutomapper.Mapping
{
    public class SourceToTargetTypeConverter : ITypeConverter<SourceType, TargetType>
    {
        private readonly IFancyService _fancyService;

        public SourceToTargetTypeConverter(IFancyService fancyService)
        {
            _fancyService = fancyService;
        }

        public TargetType Convert(SourceType source, TargetType destination, ResolutionContext context)
        {
            return new TargetType
            {
                Thing = _fancyService.GetAwesomeThing()
            };
        }
    }
}