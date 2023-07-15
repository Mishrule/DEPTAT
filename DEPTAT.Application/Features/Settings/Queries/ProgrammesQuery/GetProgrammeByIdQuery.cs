using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery
{
    public class GetProgrammeByIdQuery:IRequest<BaseResponse<ProgrammeResponse>>
    {
    public int Id { get; set; }
    public GetProgrammeByIdQuery(int id)
    {
        Id = id;
    }
    }
}
