using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.FacultyCommands;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Faculty.Validations;
using DEPTAT.Application.Exceptions;

namespace DEPTAT.Application.Features.Settings.Handlers.FacultyHandlers
{
    public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand, BaseResponse<FacultyResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFacultyRepository _FacultyRepository;

        public UpdateFacultyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IFacultyRepository FacultyRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _FacultyRepository = FacultyRepository;
        }

        public async Task<BaseResponse<FacultyResponse>> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<FacultyResponse>();
            var validator = new UpdateFacultyDtoValidator(_FacultyRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateFacultyDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            //response.IsSuccess = false;
            //response.Message = "Update Failed";
            //response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            var Faculty = await _unitOfWork.FacultyRepository.Get(y => y.Id == request.UpdateFacultyDto.Id);
            if (Faculty == null)
                throw new NotFoundException(nameof(Faculty), request.UpdateFacultyDto.Id);

            _mapper.Map(request.UpdateFacultyDto, Faculty);
            await _unitOfWork.FacultyRepository.Update(Faculty);
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
