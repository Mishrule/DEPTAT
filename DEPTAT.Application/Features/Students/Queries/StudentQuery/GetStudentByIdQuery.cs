using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Students.Queries.StudentQuery
{
    public class GetStudentByIdQuery : IRequest<BaseResponse<StudentResponse>>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
