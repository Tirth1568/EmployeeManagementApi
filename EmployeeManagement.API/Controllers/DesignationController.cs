using EmployeeManagement.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _designationService.GetDesignationsAsync());
        }
    }
}
