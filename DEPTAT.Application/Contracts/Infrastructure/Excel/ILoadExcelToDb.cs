using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DEPTAT.Application.Contracts.Infrastructure.Excel
{
    public interface ILoadExcelToDb<T> where T : class
    {
        Task<List<T>> LoadExcelFile(IFormFile file);
    }
}
