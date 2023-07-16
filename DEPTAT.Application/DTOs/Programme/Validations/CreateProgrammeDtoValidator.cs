using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Programme.Validations
{
    public class CreateProgrammeDtoValidator: AbstractValidator<CreateProgrammeDto>
    {
        public readonly IProgrammeRepository _ProgrammeRepository;

        public CreateProgrammeDtoValidator(IProgrammeRepository programmeRepository)
        {
            _ProgrammeRepository = programmeRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertName} Year Group cannot be empty");

            RuleFor(p => p.DepartmentId)
                .NotNull().WithMessage("{PropertyName} is not empty");
        }
    }
}
