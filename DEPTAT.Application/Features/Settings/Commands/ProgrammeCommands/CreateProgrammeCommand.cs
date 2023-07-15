using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.ProgrammeCommands
{
    public class CreateProgrammeCommand: IRequest<BaseResponse<ProgrammeResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
