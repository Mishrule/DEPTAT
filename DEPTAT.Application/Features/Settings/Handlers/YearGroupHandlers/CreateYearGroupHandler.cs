using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.YearGroup.Validations;
using DEPTAT.Application.Features.Settings.Commands.YearGroupCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.YearGroupHandlers
{
    public class CreateYearGroupHandler : IRequestHandler<CreateYearGroupCommand, BaseResponse<YearGroupResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateYearGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<YearGroupResponse>> Handle(CreateYearGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<YearGroupResponse>();
            var validator = new CreateYearGroupValidator(_unitOfWork.YearGroupRepository);
            var validationResult = await validator.ValidateAsync(request.CreateYearGroupDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Year Group Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var exist = await _unitOfWork.YearGroupRepository.Exists(n =>
                    n.Name == request.CreateYearGroupDto.Name);
                if (exist)
                {
                    response.IsSuccess = false;
                    response.Message = "Year Group already Exist";

                }
                else
                {
					var yearGroupEntity =  _mapper.Map<YearGroup>(request.CreateYearGroupDto);

					yearGroupEntity = await _unitOfWork.YearGroupRepository.Insert(yearGroupEntity);
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
