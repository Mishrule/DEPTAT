using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.AcademicYear;

namespace DEPTAT.Application.Features.Settings.Commands.AcademicYearCommands
{
    public class CreateAcademicYearCommand : IRequest<BaseResponse<AcademicYearResponse>>
    {
        public CreateAcademicYearDto CreateAcademicYearDto { get; }
    }
}
