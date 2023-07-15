using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Department.Validations
{
    public class CreateDepartmentDtoValidator: AbstractValidator<CreateDepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public CreateDepartmentDtoValidator(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertName} Year Group cannot be empty")
                .MustAsync(async (name, token) =>
                {
                    var nameExist = await _departmentRepository.Exists(n => n.Name.Equals(name));
                    return nameExist;
                }).WithMessage("{Property} already exist");

            RuleFor(f => f.FacultyId).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
