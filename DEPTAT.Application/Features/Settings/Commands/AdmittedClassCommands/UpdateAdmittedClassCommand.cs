using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.AdmittedClass;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.AdmittedClassCommands
{
    public class UpdateAdmittedClassCommand: IRequest<BaseResponse<AdmittedClassResponse>>
    {
        public UpdateAdmittedClassDto UpdateAdmittedClassDto { get; }

    }
}
