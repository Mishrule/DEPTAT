using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.FacultyQuery
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
