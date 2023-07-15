﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery
{
    public class GetFacultiesQuery:IRequest<BaseResponseList<FacultyResponse>>
    {
    public GetFacultiesQuery() { }
}
}
