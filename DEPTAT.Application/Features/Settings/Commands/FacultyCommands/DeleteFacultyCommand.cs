﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.FacultyCommands
{
    public class DeleteFacultyCommand:IRequest<BaseResponse<FacultyResponse>>
    {
        public int Id { get; set; }
    }
}
