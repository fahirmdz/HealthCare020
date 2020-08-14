using HealthCare020.API.Constants;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [ApiController]
    public class BaseController<TEntity, TResourceParameters> : ControllerBase where TResourceParameters : BaseResourceParameters
    {
        private readonly IService<TEntity, TResourceParameters> _service;

        public BaseController(IService<TEntity, TResourceParameters> service)
        {
            _service = service;
        }

        [HttpGet]
        [HttpHead]
        public virtual async Task<IActionResult> Get([FromQuery] TResourceParameters resourceParameters)
        {
            var result = await _service.Get(resourceParameters);

            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            if (result.Data is SequenceResult resultSequence)
            {
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(resultSequence.PaginationMetadata));

                return Ok(resultSequence.Data);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        [Authorize]
        public virtual async Task<IActionResult> GetById(int id, [FromQuery] bool? EagerLoaded = false)
        {
            var result = await _service.GetById(id, EagerLoaded ?? false);

            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            return Ok(result.Data);
        }

        //Last MonthsCount months for entities with DateTime property
        [HttpGet("count")]
        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public async Task<IActionResult> Count(int MonthsCount = 0) => Ok(await _service.Count(MonthsCount));

        protected IActionResult WithStatusCode(HttpStatusCode statusCode, string message = "")
        {
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(message);

                case HttpStatusCode.Forbidden:
                    return StatusCode(403, message);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized();

                case HttpStatusCode.BadRequest:
                    return BadRequest(message);

                default:
                    return StatusCode((int)statusCode);
            }
        }
    }
}