using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Settings.Queries.StudentQuery.cs
{
    public class GetStudentsQuery : IRequest<BaseResponseList<StudentResponse>>
    {
        public GetStudentsQuery() { }
    }
}
