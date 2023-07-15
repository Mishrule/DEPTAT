using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Faculty.Validations;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Department.Validations
{
    public class UpdateDepartmentDtoValidator : AbstractValidator<UpdateDepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public UpdateDepartmentDtoValidator(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            Include(new IDepartmentDtoValidator(_departmentRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
