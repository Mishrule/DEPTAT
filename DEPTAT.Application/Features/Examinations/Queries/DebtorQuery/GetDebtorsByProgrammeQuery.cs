using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Examinations.Queries.DebtorQuery
{
    public class GetDebtorsByProgrammeQuery:IRequest<BaseResponse<DebtorsResponse>>
    {
    public int _programme { get; set; }

    public GetDebtorsByProgrammeQuery(int programme)
    {
        _programme = programme;
    }
    }
}
