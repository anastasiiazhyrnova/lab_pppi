using ClosedXML.Excel;

namespace WebAPI_Labs.Services.ContentService.V3
{
    public interface IExcelService
    {
        Task<XLWorkbook> GetContent();
    }
}
