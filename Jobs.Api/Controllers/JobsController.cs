using Jobs.Api.Interfaces;
using Jobs.Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;
        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            try
            {
                var result = _jobsService.List();
                if (result.Count() <= 0)
                {
                    return NotFound("Não foi encontrado nenhuma informação.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Consult/{id}")]
        public IActionResult Consult(int id)
        {
            var result = _jobsService.Consult(id);
            if (result == null)
                return NotFound("Não foi encontrado nenhuma informação.");

            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(JobsRequest request)
        {
            var result = _jobsService.CreateJobs(request);
            if (result == null)
                return BadRequest("Algo deu errado.");

            return Ok(result);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update(int id, [FromQuery] JobsRequest request)
        {
            var result = _jobsService.UpdateJob(id, request);
            if (result == null)
                return BadRequest("Algo deu errado.");

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _jobsService.DeleteJob(id);
            if (!result)
                return BadRequest("Algo deu errado.");

            return Ok("Sucesso");
        }
    }
}
