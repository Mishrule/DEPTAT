﻿using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Examinations.Queries
{
    public class GetAttendanceQuery : IRequest<BaseResponseList<AttendanceResponse>>
    {
        public GetAttendanceQuery()
        {
        }
    }
}
