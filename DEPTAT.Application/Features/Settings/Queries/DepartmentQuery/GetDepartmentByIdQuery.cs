using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.YearGroupQueries
{
    public class GetDepartmentByIdQuery : IRequest<BaseResponse<DepartmentResponse>>
    {
        public int Id { get; set; }
        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
