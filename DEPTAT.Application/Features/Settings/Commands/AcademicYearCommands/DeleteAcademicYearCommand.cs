using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.AcademicYearCommands
{
    public class DeleteAcademicYearCommand:IRequest<BaseResponse<AcademicYearResponse>>
    {
        public int Id{get; set; }
    }
}
