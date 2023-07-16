using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Faculty.Validations
{
    public class CreateFacultyDtoValidator: AbstractValidator<CreateFacultyDto>
    {
        public readonly IFacultyRepository _facultyRepository;

        public CreateFacultyDtoValidator(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertName} Year Group cannot be empty");
            
        }
    }
}
