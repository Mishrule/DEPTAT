using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Examinations.Queries.DebtorQuery
{
    public class GetDebtorsQuery : IRequest<BaseResponseList<DebtorsResponse>>
    {
        public GetDebtorsQuery() { }
    }
}
