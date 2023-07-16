using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Course.Validations
{
    public class CreateCourseDtoValidator:AbstractValidator<CreateCourseDto>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseDtoValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertName} Year Group cannot be empty");

            RuleFor(f => f.ProgrammeId).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
