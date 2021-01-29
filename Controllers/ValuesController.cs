using System.Collections.Generic;
using System.Web.Http;
using AutofacAndAutomapper.Models;
using AutoMapper;

namespace AutofacAndAutomapper.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IMapper _mapper;

        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new[] {"value1", "value2"};
        //}

        // GET api/<controller>/5
        public TargetType Get([FromUri] SourceType sourceType)
        {
            return _mapper.Map<TargetType>(sourceType);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}