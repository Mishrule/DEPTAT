using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.AcademicYear.Validations;
using DEPTAT.Application.Features.Settings.Commands.AcademicYearCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.AcademicYearHandlers
{
    public class CreateAcademicYearCommandHandler : IRequestHandler<CreateAcademicYearCommand, BaseResponse<AcademicYearResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAcademicYearCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AcademicYearResponse>> Handle(CreateAcademicYearCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AcademicYearResponse>();
            var validator = new CreateAcademicYearDtoValidator(_unitOfWork.AcademicYearRepository);
            var validationResult = await validator.ValidateAsync(request.CreateAcademicYearDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Operation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var exist = await _unitOfWork.AcademicYearRepository.Exists(n => n.Name == request.CreateAcademicYearDto.Name);

				if (exist)
                {
                    response.IsSuccess = false;
                    response.Message = "Data already Exist";

                }
                else
                {
					var AcademicYearEntity = _mapper.Map<AcademicYear>(request.CreateAcademicYearDto);

					AcademicYearEntity = await _unitOfWork.AcademicYearRepository.Insert(AcademicYearEntity);
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

               
            }

            return response;
        }
    }
}
