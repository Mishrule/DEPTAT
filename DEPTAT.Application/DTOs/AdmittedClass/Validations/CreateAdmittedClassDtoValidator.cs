using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.AdmittedClass.Validations
{
    public class CreateAdmittedClassDtoValidator: AbstractValidator<CreateAdmittedClassDto>
    {
        private readonly IAdmittedClassRepository _admittedClassRepository;

        public CreateAdmittedClassDtoValidator(IAdmittedClassRepository admittedClassRepository)
        {
            _admittedClassRepository = admittedClassRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertName} Year Group cannot be empty")
                .MustAsync(async (name, token) =>
                {
                    var nameExist = await _admittedClassRepository.Exists(n => n.Name.Equals(name));
                    return nameExist;
                }).WithMessage("{Property} already exist");

            RuleFor(f => f.Name).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
