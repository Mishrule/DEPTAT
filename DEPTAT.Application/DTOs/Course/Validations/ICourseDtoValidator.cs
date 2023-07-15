using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Course.Validations
{
    public class ICourseDtoValidator:AbstractValidator<ICourseDto>
    {
        private readonly ICourseRepository _courseRepository;

        public ICourseDtoValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null")
                .MustAsync(async (name, token) =>
                {
                    var nameExits = await _courseRepository.Exists(name => name.Name.Equals(name));
                    return nameExits;
                }).WithMessage("{PropertyName} already exist.");

            RuleFor(p => p.Code)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null"); 
            RuleFor(p => p.ProgrammeId)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null");

        }
    }
}
