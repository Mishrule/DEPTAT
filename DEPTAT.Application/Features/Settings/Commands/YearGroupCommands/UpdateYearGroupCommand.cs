﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.YearGroup;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.YearGroupCommands
{
    public class UpdateYearGroupCommand:IRequest<BaseResponse<YearGroupResponse>>
    {
        public UpdateYearGroupDto UpdateYearGroupDto { get; set; }

    }
}
