using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.YearGroup.Validations;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Programme.Validations
{
    public class UpdateProgrammeDtoValidator: AbstractValidator<UpdateProgrammeDto>
    {
        private readonly IProgrammeRepository _programmeRepository;

        public UpdateProgrammeDtoValidator(IProgrammeRepository programmeRepository)
        {
            _programmeRepository = programmeRepository;
            Include(new IProgrammeDtoValidator(_programmeRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
