using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Course.Validations;
using FluentValidation;

namespace DEPTAT.Application.DTOs.AdmittedClass.Validations
{
    public class UpdateAdmittedClassDtoValidator : AbstractValidator<UpdateAdmittedClassDto>
    {
        private readonly IAdmittedClassRepository _admittedClassRepository;

        public UpdateAdmittedClassDtoValidator(IAdmittedClassRepository admittedClassRepository)
        {
            _admittedClassRepository = admittedClassRepository;
            Include(new IAdmittedClassDtoValidator(_admittedClassRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
