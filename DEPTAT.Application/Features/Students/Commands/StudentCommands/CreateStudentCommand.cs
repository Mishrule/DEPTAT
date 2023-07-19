using DEPTAT.Application.DTOs.Student;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Students.Commands.StudentCommands
{
    public class CreateStudentCommand : IRequest<BaseResponse<StudentResponse>>
    {
        public CreateStudentDto CreateStudentDto { get; set; }
    }
}
