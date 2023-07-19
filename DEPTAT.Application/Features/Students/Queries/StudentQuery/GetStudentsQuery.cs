using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Students.Queries.StudentQuery
{
    public class GetStudentsQuery : IRequest<BaseResponseList<StudentResponse>>
    {
        public GetStudentsQuery() { }
    }
}
