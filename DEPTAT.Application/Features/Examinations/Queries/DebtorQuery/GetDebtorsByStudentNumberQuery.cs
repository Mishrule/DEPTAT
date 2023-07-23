using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Examinations.Queries.DebtorQuery
{
    public class GetDebtorsByStudentNumberQuery : IRequest<BaseResponse<DebtorsResponse>>
    {
        public string _studentNumber { get; set; }

        public GetDebtorsByStudentNumberQuery(string studentNumber)
        {
            _studentNumber = studentNumber;
        }
    }
}
