using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Faculty.Validations
{
    public class IFacultyDtoValidator:AbstractValidator<IFacultyDto>
    {
        private IFacultyRepository _facultyRepository;

        public IFacultyDtoValidator(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null")
                .MustAsync(async (name, token) =>
                {
                    var nameExits = await _facultyRepository.Exists(name => name.Name.Equals(name));
                    return nameExits;
                }).WithMessage("{PropertyName} already exist.");

        }
    }
}
