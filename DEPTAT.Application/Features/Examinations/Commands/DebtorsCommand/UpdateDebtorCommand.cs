using DEPTAT.Application.DTOs.Student;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Debtors;

namespace DEPTAT.Application.Features.Examinations.Commands.DebtorsCommand
{
    public class UpdateDebtorCommand : IRequest<BaseResponse<DebtorsResponse>>
    {
        public UpdateDebtorsDto UpdateDebtorsDto { get; set; }

    }
}
