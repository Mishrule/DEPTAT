using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Programme.Validations;
using DEPTAT.Application.Features.Settings.Commands.ProgrammeCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.ProgrammeHandlers
{
    public class CreateProgrammeCommandHandler : IRequestHandler<CreateProgrammeCommand, BaseResponse<ProgrammeResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProgrammeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProgrammeResponse>> Handle(CreateProgrammeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProgrammeResponse>();
            var validator = new CreateProgrammeDtoValidator(_unitOfWork.ProgrammeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateProgrammeDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Operation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                if (await _unitOfWork.ProgrammeRepository.Exists(n => n.Name == request.CreateProgrammeDto.Name))
                {
                    response.IsSuccess = false;
                    response.Message = "Data already Exist";
                    
                }

                var programmeEntity = _mapper.Map<Programme>(request.CreateProgrammeDto);

                programmeEntity = await _unitOfWork.ProgrammeRepository.Insert(programmeEntity);
                var save = await _unitOfWork.Save();
                if (save)
                {
                    response.IsSuccess = true;
                    response.Message = "Record saved Successfully";
                }
                else
                {
                    response.Message = "Save Failed Try again";
                    response.IsSuccess = false;
                }
            }

            return response;
        }
    }
}
