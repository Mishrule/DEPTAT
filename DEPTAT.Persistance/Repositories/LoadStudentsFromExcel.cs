using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Infrastructure.Excel;
using DEPTAT.Application.DTOs.Common;
using DEPTAT.Application.Responses;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace DEPTAT.Persistance.Repositories
{
    public class LoadStudentsFromExcel: ILoadExcelToDb<StudentResponse>
    {
        public async Task<List<StudentResponse>> LoadExcelFile(IFormFile file)
        {
            List<StudentResponse> output = new();

            using var package = new ExcelPackage(file.OpenReadStream());
            var ws = package.Workbook.Worksheets[0];

            int row = 2;
            int col = 1;

            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
            {
                StudentResponse p = new();
                p.StudentNumber = ws.Cells[row, col].Value?.ToString();
                p.FirstName = ws.Cells[row, col + 1].Value?.ToString();
                p.OtherName = ws.Cells[row, col + 2].Value?.ToString();
                p.LastName = ws.Cells[row, col + 3].Value?.ToString();
                p.Status = ParseEnum<StudentStatus>(ws.Cells[row, col + 4].Value.ToString());
                p.AcademicYear = ws.Cells[row, col + 5].Value?.ToString();
                p.ClassYear = ws.Cells[row, col + 6].Value?.ToString();
                p.YearGroup = int.Parse(ws.Cells[row, col + 7].Value?.ToString());
                p.AdmittedYear = ws.Cells[row, col + 8].Value?.ToString();
                p.ProgrammeId = int.Parse(ws.Cells[row, col + 9].Value?.ToString());
                p.PhoneNumber = ws.Cells[row, col + 10].Value?.ToString();
                p.Email = ws.Cells[row, col + 11].Value?.ToString();
                p.ImageUrl = ws.Cells[row, col + 12].Value?.ToString();
                output.Add(p);
                row += 1;
            }

            return output;
        }

        public static TEnum ParseEnum<TEnum>(string value) where TEnum : struct
        {
            if (Enum.TryParse(value, out TEnum result))
            {
                return result;
            }
            // Handle the case where the string does not match any enum values
            throw new ArgumentException("Invalid enum value: " + value);
        }
    }
}
