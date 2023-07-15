using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.YearGroupCommands
{
    public class DeleteYearGroupCommand : IRequest<BaseResponse<YearGroupResponse>>
    {
        public int Id { get; set; }
    }
}
