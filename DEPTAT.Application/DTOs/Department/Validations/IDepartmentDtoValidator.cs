using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using FluentValidation;

namespace DEPTAT.Application.DTOs.Department.Validations
{
    public class IDepartmentDtoValidator :AbstractValidator<IDepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public IDepartmentDtoValidator(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null")
                .MustAsync(async (name, token) =>
                {
                    var nameExits = await _departmentRepository.Exists(name => name.Name.Equals(name));
                    return nameExits;
                }).WithMessage("{PropertyName} already exist.");

        }
    }
}
