using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.AdmittedClass.Validations;
using DEPTAT.Application.Features.Settings.Commands.AdmittedClassCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.AdmittedClassHandlers
{
    public class CreateAdmittedClassCommandHandler : IRequestHandler<CreateAdmittedClassCommand, BaseResponse<AdmittedClassResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAdmittedClassCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AdmittedClassResponse>> Handle(CreateAdmittedClassCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AdmittedClassResponse>();
            var validator = new CreateAdmittedClassDtoValidator(_unitOfWork.AdmittedClassRepository);
            var validationResult = await validator.ValidateAsync(request.CreateAdmittedClassDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Operation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                if (await _unitOfWork.AdmittedClassRepository.Exists(n => n.Name == request.CreateAdmittedClassDto.Name))
                {
                    response.IsSuccess = false;
                    response.Message = "Data already Exist";
                    
                }

                var AdmittedClassEntity = _mapper.Map<AdmittedClass>(request.CreateAdmittedClassDto);

                AdmittedClassEntity = await _unitOfWork.AdmittedClassRepository.Insert(AdmittedClassEntity);
                var save = await _unitOfWork.Save();
                if (save)
                {
                    response.IsSuccess = true;
                    response.Message = "Success: Record save Successfully";
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
