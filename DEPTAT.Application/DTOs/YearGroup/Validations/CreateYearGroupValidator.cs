﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.YearGroup.Validations
{
    public class CreateYearGroupValidator:AbstractValidator<CreateYearGroupDto>
    {
        private readonly IYearGroupRepository _yearGroupRepository;

        public CreateYearGroupValidator(IYearGroupRepository yearGroupRepository)
        {
            _yearGroupRepository = yearGroupRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertName} Year Group cannot be empty");

        }
    }
}
