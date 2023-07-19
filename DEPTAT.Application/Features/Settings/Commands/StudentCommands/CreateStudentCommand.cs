using DEPTAT.Application.DTOs.Programme;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Student;

namespace DEPTAT.Application.Features.Settings.Commands.StudentCommands
{
    public class CreateStudentCommand : IRequest<BaseResponse<StudentResponse>>
    {
        public CreateStudentDto CreateStudentDto { get; set; }
    }
}
