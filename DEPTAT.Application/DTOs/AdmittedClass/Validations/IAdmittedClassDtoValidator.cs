using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.AdmittedClass.Validations
{
    public class IAdmittedClassDtoValidator:AbstractValidator<IAdmittedClassDto>
    {
        private readonly IAdmittedClassRepository _admittedClassRepository;

        public IAdmittedClassDtoValidator(IAdmittedClassRepository admittedClassRepository)
        {
            _admittedClassRepository = admittedClassRepository;
            
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null")
                .MustAsync(async (name, token) =>
                {
                    var nameExits = await _admittedClassRepository.Exists(name => name.Name.Equals(name));
                    return nameExits;
                }).WithMessage("{PropertyName} already exist.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null");
            
        }
    }
}
