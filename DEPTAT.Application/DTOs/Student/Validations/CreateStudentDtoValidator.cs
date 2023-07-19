using DEPTAT.Application.DTOs.Programme;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.DTOs.Student.Validations
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {


        public CreateStudentDtoValidator(IStudentRepository studentRepository)
        {
            RuleFor(p => p.IndexNumber).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.Status).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.AcademicYear).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.AdmittedYear).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.ProgrammeId).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.ClassYear).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
