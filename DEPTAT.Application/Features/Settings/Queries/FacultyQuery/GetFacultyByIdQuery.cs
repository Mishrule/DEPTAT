using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery
{
    public class GetFacultyByIdQuery:IRequest<BaseResponse<FacultyResponse>>
    {
    public int Id { get; set; }
    public GetFacultyByIdQuery(int id)
    {
        Id = id;
    }
    }
}
