using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.YearGroup.Validations
{
    public class IYearGroupDtoValidator:AbstractValidator<IYearGroupDto>
    {
        private readonly IYearGroupRepository _yearGroupRepository;

        public IYearGroupDtoValidator(IYearGroupRepository yearGroupRepository)
        {
            _yearGroupRepository = yearGroupRepository;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null")
                .MustAsync(async (name, token) =>
                {
                    var nameExits = await _yearGroupRepository.Exists(name=>name.Name.Equals(name));
                    return nameExits;
                }).WithMessage("{PropertyName} already exist.");

        }
    }
}
