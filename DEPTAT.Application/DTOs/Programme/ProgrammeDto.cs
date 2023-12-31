﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Department;
using DEPTAT.Domain.Common;

namespace DEPTAT.Application.DTOs.Programme
{
    public class ProgrammeDto:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
