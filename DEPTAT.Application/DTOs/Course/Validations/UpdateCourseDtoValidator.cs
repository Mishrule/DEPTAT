using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Department.Validations;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Course.Validations
{
    public class UpdateCourseDtoValidator:AbstractValidator<UpdateCourseDto>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseDtoValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            Include(new ICourseDtoValidator(_courseRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
