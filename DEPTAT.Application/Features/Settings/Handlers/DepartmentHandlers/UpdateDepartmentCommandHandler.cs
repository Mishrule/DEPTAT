using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.DepartmentCommands;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Department.Validations;
using DEPTAT.Application.Exceptions;

namespace DEPTAT.Application.Features.Settings.Handlers.DepartmentHandlers
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, BaseResponse<DepartmentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _DepartmentRepository;

        public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IDepartmentRepository DepartmentRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _DepartmentRepository = DepartmentRepository;
        }

        public async Task<BaseResponse<DepartmentResponse>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<DepartmentResponse>();
            //var validator = new UpdateDepartmentDtoValidator(_DepartmentRepository);
            //var validationResult = await validator.ValidateAsync(request.UpdateDepartmentDto);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);
            //response.IsSuccess = false;
            //response.Message = "Update Failed";
            //response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            var Department = await _unitOfWork.DepartmentRepository.Get(y => y.Id == request.UpdateDepartmentDto.Id);
            if (Department == null)
                throw new NotFoundException(nameof(Department), request.UpdateDepartmentDto.Id);

            _mapper.Map(request.UpdateDepartmentDto, Department);
            await _unitOfWork.DepartmentRepository.Update(Department);
            var save = await _unitOfWork.Save();
            if (save)
            {
                response.IsSuccess = true;
                response.Message = "Record updated Successfully";
            }
            else
            {
                response.Message = "Error: Update Failed Try again";
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
