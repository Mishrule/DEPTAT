using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Faculty;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.FacultyCommands
{
    public class UpdateFacultyCommand: IRequest<BaseResponse<FacultyResponse>>
    {
        public UpdateFacultyDto UpdateFacultyDto { get; }

    }
}
