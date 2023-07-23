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
    public class CreateDebtorCommand : IRequest<BaseResponse<DebtorsResponse>>
    {
        public CreateDebtorsDto CreateDebtorsDto { get; set; }
    }
}
