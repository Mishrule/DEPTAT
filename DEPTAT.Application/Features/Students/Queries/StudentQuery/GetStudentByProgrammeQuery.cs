using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Students.Queries.StudentQuery
{
    public class GetStudentByProgrammeQuery : IRequest<BaseResponseList<StudentResponse>>
    {
        public int ProgrammeId { get; set; }

        public GetStudentByProgrammeQuery(int programmeId)
        {
            ProgrammeId = programmeId;
        }
    }
}
