﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Common;

namespace DEPTAT.Domain.Entities
{
    public class Department: BaseDomainEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int FacultyId {get; set; }
        public Faculty Faculty { get; set; }
    }
}
