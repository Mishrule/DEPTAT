using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.AdmittedClass.Validations;
using FluentValidation;

namespace DEPTAT.Application.DTOs.AcademicYear.Validations
{
    public class UpdateAcademicYearDtoValidator:AbstractValidator<UpdateAcademicYearDto>
    {
        private readonly IAcademicYearRepository _academicYearRepository;

        public UpdateAcademicYearDtoValidator(IAcademicYearRepository academicYearRepository)
        {
            _academicYearRepository = academicYearRepository;
            Include(new IAcademicYearDtoValidator(_academicYearRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
