using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Programme.Validations;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Faculty.Validations
{
    public class UpdateFacultDtoValidator: AbstractValidator<UpdateFacultyDto>
    {
        public readonly IFacultyRepository _facultyRepository;

        public UpdateFacultDtoValidator(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
            Include(new IFacultyDtoValidator(_facultyRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
