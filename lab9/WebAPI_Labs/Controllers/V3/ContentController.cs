using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Labs.Services.ContentService.V1;
using WebAPI_Labs.Services.ContentService.V2;
using WebAPI_Labs.Services.ContentService.V3;

namespace WebAPI_Labs.Controllers.V3
{
    [ApiVersion("3.0")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v3")]
    [Route("api/v3/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IExcelService _excelService;

        public ContentController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            var workbook = await _excelService.GetContent();
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "excelFile.xlsx");
        }
    }
}
