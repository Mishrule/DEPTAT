using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.DepartmentCommands
{
    public class CreateDepartmentCommand : IRequest<BaseResponse<DepartmentResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FacultyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
