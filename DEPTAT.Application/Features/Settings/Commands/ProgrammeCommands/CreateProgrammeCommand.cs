using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Programme;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.ProgrammeCommands
{
    public class CreateProgrammeCommand: IRequest<BaseResponse<ProgrammeResponse>>
    {
        public CreateProgrammeDto CreateProgrammeDto { get; set; }
       

    }
}
