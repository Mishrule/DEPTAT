using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.CourseCommands
{
    public class CreateCourseCommand:IRequest<BaseResponse<CourseResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int ProgrammeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
