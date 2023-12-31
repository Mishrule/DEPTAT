﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Common;

namespace DEPTAT.Application.DTOs.YearGroup
{
    public class UpdateYearGroupDto : BaseDTO, IYearGroupDto
    {
        public int Name { get; set; }
        public string Description { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
