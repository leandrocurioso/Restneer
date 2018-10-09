using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restneer.Core.Application.UseCase.ApiRole;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Web.Api.Controllers
{

    [Route("api/api-role")]
    [ApiController]
    public class ApiRoleController : ControllerBase
    {
        readonly IApiRoleUseCase _apiRoleUseCase;

        public ApiRoleController(IApiRoleUseCase apiRoleUseCase)
        {
            _apiRoleUseCase = apiRoleUseCase;
        }

        // GET api/api-role
        [HttpGet]
        public async Task<IEnumerable<ApiRoleEntity>> Get()
        {
            var queryParam = new QueryParam<ApiRoleEntity>();
            throw new Exception("Exception while fetching all the students from the storage.");
            return await _apiRoleUseCase.List(queryParam);
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
