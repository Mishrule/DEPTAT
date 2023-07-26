using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DEPTAT.Application.Features.Students.Queries.StudentQuery
{
    public class GetTotalOTPQuery : IRequest<int>
    {
        public GetTotalOTPQuery()
        {
        }
    }
}
