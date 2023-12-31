﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Programme;
using DEPTAT.Domain.Common;

namespace DEPTAT.Application.DTOs.Course
{
    public class CourseDto:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int ProgrammeId { get; set; }
        public ProgrammeDto Programme { get; set; }

    }
}
