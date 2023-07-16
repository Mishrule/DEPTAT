using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Department;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.DepartmentCommands
{
    public class UpdateDepartmentCommand: IRequest<BaseResponse<DepartmentResponse>>
    {
      public  UpdateDepartmentDto UpdateDepartmentDto { get; set; }

    }
}
