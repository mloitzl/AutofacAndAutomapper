using System;
using AutofacAndAutomapper.Mapping;
using AutofacAndAutomapper.Models;

namespace AutofacAndAutomapper.Services
{
    public class FancyService : IFancyService
    {
        public AwesomeThing GetAwesomeThing()
        {
            return new AwesomeThing
            {
                Data = "Yeah!"
            };
        }
    }
}