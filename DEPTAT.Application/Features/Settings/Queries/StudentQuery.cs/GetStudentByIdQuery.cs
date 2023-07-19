using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Settings.Queries.StudentQuery.cs
{
    public class GetStudentByIdQuery : IRequest<BaseResponse<StudentResponse>>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
