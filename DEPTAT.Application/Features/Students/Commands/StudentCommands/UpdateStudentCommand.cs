using DEPTAT.Application.DTOs.Programme;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Student;

namespace DEPTAT.Application.Features.Students.Commands.StudentCommands
{
    public class UpdateStudentCommand : IRequest<BaseResponse<StudentResponse>>
    {
        public UpdateStudentDto UpdateStudentDto { get; set; }

    }
}
