using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restneer.Core.Domain.Business.ApiRole;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Repository.ApiRole;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Restneer.Web.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly Container _container;

        public ValuesController(Container container)
        {
            _container = container;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ApiRoleEntity>> Get()
        {
            using (AsyncScopedLifestyle.BeginScope(_container))
            {
                var apiRoleBusiness1 = _container.GetInstance<IApiRoleBusiness>();
                var list1 = await apiRoleBusiness1.List();
                var list2 = await apiRoleBusiness1.List();
                var apiRoleBusiness2 = _container.GetInstance<IApiRoleBusiness>();
                var list3 = await apiRoleBusiness2.List();
                var list4 = await apiRoleBusiness2.List();
                return list1.Concat(list2).Concat(list3).Concat(list4);
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
