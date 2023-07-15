using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.YearGroup.Validations
{
    public class UpdateYearGroupValidator : AbstractValidator<UpdateYearGroupDto>
    {
        private readonly IYearGroupRepository _yearGroupRepository;

        public UpdateYearGroupValidator(IYearGroupRepository yearGroupRepository)
        {
            _yearGroupRepository = yearGroupRepository;
            Include(new IYearGroupDtoValidator(_yearGroupRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
