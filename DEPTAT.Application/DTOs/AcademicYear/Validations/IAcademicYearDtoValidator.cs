using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.AcademicYear.Validations
{
    public class IAcademicYearDtoValidator:AbstractValidator<IAcademicYearDto>
    {
        private readonly IAcademicYearRepository _academicYearRepository;

        public IAcademicYearDtoValidator(IAcademicYearRepository academicYearRepository)
        {
            _academicYearRepository = academicYearRepository;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null")
                .MustAsync(async (name, token) =>
                {
                    var nameExits = await _academicYearRepository.Exists(name => name.Name.Equals(name));
                    return nameExits;
                }).WithMessage("{PropertyName} already exist.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null");
        }
    }
}
