using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.AdmittedClassCommands;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.AdmittedClass.Validations;
using DEPTAT.Application.Exceptions;

namespace DEPTAT.Application.Features.Settings.Handlers.AdmittedClassHandlers
{
    public class UpdateAdmittedClassCommandHandler : IRequestHandler<UpdateAdmittedClassCommand, BaseResponse<AdmittedClassResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAdmittedClassRepository _AdmittedClassRepository;

        public UpdateAdmittedClassCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAdmittedClassRepository AdmittedClassRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _AdmittedClassRepository = AdmittedClassRepository;
        }

        public async Task<BaseResponse<AdmittedClassResponse>> Handle(UpdateAdmittedClassCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AdmittedClassResponse>();
            var validator = new UpdateAdmittedClassDtoValidator(_AdmittedClassRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateAdmittedClassDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            //response.IsSuccess = false;
            //response.Message = "Update Failed";
            //response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            var AdmittedClass = await _unitOfWork.AdmittedClassRepository.Get(y => y.Id == request.UpdateAdmittedClassDto.Id);
            if (AdmittedClass == null)
                throw new NotFoundException(nameof(AdmittedClass), request.UpdateAdmittedClassDto.Id);

            _mapper.Map(request.UpdateAdmittedClassDto, AdmittedClass);
            await _unitOfWork.AdmittedClassRepository.Update(AdmittedClass);
            var save = await _unitOfWork.Save();
            if (save)
            {
                response.IsSuccess = true;
                response.Message = "Success: Record updated Successfully";
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
