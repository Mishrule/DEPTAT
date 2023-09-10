using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Infrastructure.Excel;
using DEPTAT.Application.Responses;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace DEPTAT.Persistance.Repositories
{
    public class LoadExcelToDb: ILoadExcelToDb<DebtorsResponse>
    {
    
    public async Task<List<DebtorsResponse>> LoadExcelFile(IFormFile file)
    {
        List<DebtorsResponse> output = new();

        using var package = new ExcelPackage(file.OpenReadStream());
        var ws = package.Workbook.Worksheets[0];

        int row = 2;
        int col = 1;

        while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
        {
            DebtorsResponse p = new();
            p.StudentNumber = ws.Cells[row, col].Value?.ToString();
            p.Semester = (Application.DTOs.Common.Semester)int.Parse(ws.Cells[row, col + 1].Value?.ToString());
            p.AcademicYear = ws.Cells[row, col + 2].Value?.ToString();
            p.AmountPaid = decimal.Parse(ws.Cells[row, col + 3].Value?.ToString());
            p.AmountBilled = decimal.Parse(ws.Cells[row, col + 4].Value?.ToString());
            output.Add(p);
            row += 1;
        }

        return output;
    }
    }
}

