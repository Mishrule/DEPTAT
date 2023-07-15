using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Programme.Validations
{
    public class IProgrammeDtoValidator : AbstractValidator<IProgrammeDto>
    {
        private IProgrammeRepository _programmeRepository;

        public IProgrammeDtoValidator(IProgrammeRepository programmeRepository)
        {
            _programmeRepository = programmeRepository;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null")
                .MustAsync(async (name, token) =>
                {
                    var nameExits = await _programmeRepository.Exists(name => name.Name.Equals(name));
                    return nameExits;
                }).WithMessage("{PropertyName} already exist.");

        }
    }
}
