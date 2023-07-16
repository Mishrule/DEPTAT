using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.FacultyQuery
{
    public class GetFacultiesQuery:IRequest<BaseResponseList<FacultyResponse>>
    {
    public GetFacultiesQuery() { }
}
}
