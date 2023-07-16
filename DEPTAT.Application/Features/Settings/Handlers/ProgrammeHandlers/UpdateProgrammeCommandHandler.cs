using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.ProgrammeCommands;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Programme.Validations;
using DEPTAT.Application.Exceptions;

namespace DEPTAT.Application.Features.Settings.Handlers.ProgrammeHandlers
{
    public class UpdateProgrammeCommandHandler : IRequestHandler<UpdateProgrammeCommand, BaseResponse<ProgrammeResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProgrammeRepository _ProgrammeRepository;

        public UpdateProgrammeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IProgrammeRepository ProgrammeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ProgrammeRepository = ProgrammeRepository;
        }

        public async Task<BaseResponse<ProgrammeResponse>> Handle(UpdateProgrammeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProgrammeResponse>();
            //var validator = new UpdateProgrammeDtoValidator(_ProgrammeRepository);
            //var validationResult = await validator.ValidateAsync(request.UpdateProgrammeDto);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);
            //response.IsSuccess = false;
            //response.Message = "Update Failed";
            //response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            var Programme = await _unitOfWork.ProgrammeRepository.Get(y => y.Id == request.UpdateProgrammeDto.Id);
            if (Programme == null)
                throw new NotFoundException(nameof(Programme), request.UpdateProgrammeDto.Id);

            _mapper.Map(request.UpdateProgrammeDto, Programme);
            await _unitOfWork.ProgrammeRepository.Update(Programme);
            var save = await _unitOfWork.Save();
            if (save)
            {
                response.IsSuccess = true;
                response.Message = "Record updated Successfully";
            }
            else
            {
                response.Message = "Update Failed Try again";
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
