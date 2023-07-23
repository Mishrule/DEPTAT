using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Students.Queries.StudentQuery
{
    public class GetStudentByIdQuery : IRequest<BaseResponse<StudentResponse>>
    {
        public string StudentNumber { get; set; }

        public GetStudentByIdQuery(string studentNumber)
        {
            StudentNumber = studentNumber;
        }
    }
}
