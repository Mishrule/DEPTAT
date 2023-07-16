using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Department.Validations;
using DEPTAT.Application.DTOs.YearGroup.Validations;
using DEPTAT.Application.Features.Settings.Commands.DepartmentCommands;
using DEPTAT.Application.Features.Settings.Commands.YearGroupCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using FluentValidation;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.YearGroupHandlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseResponse<DepartmentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DepartmentResponse>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<DepartmentResponse>();
            var validator = new CreateDepartmentDtoValidator(_unitOfWork.DepartmentRepository);
            var validationResult = await validator.ValidateAsync(request.CreateDepartmentDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Operation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                if (await _unitOfWork.DepartmentRepository.Exists(n => n.Name == request.CreateDepartmentDto.Name))
                {
                    response.IsSuccess = false;
                    response.Message = "Data already Exist";
                    
                }

                var DepartmentEntity = _mapper.Map<Department>(request.CreateDepartmentDto);

                DepartmentEntity = await _unitOfWork.DepartmentRepository.Insert(DepartmentEntity);
                var save = await _unitOfWork.Save();
                if (save)
                {
                    response.IsSuccess = true;
                    response.Message = "Record Saved";
                }
                else
                {
                    response.Message = "Error: Save Failed Try again";
                    response.IsSuccess = false;
                }
            }

            return response;
        }
    }
}
