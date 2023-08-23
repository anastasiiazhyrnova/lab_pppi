﻿using ClosedXML.Excel;

namespace WebAPI_Labs.Services.ContentService.V3
{
    public class ExcelService : IExcelService
    {
        public async Task<XLWorkbook> GetContent()
        {
            try
            {
                return await Task.Run(() =>
                {
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Sample Sheet");
                    worksheet.Cell("A1").Value = "Hello World!";
                    worksheet.Cell("A2").FormulaA1 = "=MID(A1, 7, 5)";
                    return workbook;
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
