using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Course;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.CourseCommands
{
    public class UpdateCourseCommand:IRequest<BaseResponse<CourseResponse>>
    {
        public UpdateCourseDto UpdateCourseDto { get; set; }

    }
}
