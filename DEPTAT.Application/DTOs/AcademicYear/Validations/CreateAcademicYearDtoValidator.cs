using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.AcademicYear.Validations
{
    public class CreateAcademicYearDtoValidator:AbstractValidator<CreateAcademicYearDto>
    {
        private readonly IAcademicYearRepository _academicYearRepository;

        public CreateAcademicYearDtoValidator(IAcademicYearRepository academicYearRepository)
        {
            _academicYearRepository = academicYearRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertName} Year Group cannot be empty")
                .MustAsync(async (name, token) =>
                {
                    var nameExist = await _academicYearRepository.Exists(n => n.Name.Equals(name));
                    return nameExist;
                }).WithMessage("{Property} already exist");

            RuleFor(f => f.Name).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
