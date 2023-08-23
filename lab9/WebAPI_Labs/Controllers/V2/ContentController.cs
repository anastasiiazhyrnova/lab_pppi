using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Labs.Services.ContentService.V1;
using WebAPI_Labs.Services.ContentService.V2;

namespace WebAPI_Labs.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/v2/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IStringService _stringService;

        public ContentController(IStringService stringService)
        {
            _stringService = stringService;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _stringService.GetContent());
        }
    }
}
