using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.AcademicYearCommands;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.AcademicYear.Validations;
using DEPTAT.Application.Exceptions;

namespace DEPTAT.Application.Features.Settings.Handlers.AcademicYearHandlers
{
    public class UpdateAcademicYearCommandHandler : IRequestHandler<UpdateAcademicYearCommand, BaseResponse<AcademicYearResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAcademicYearRepository _AcademicYearRepository;

        public UpdateAcademicYearCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAcademicYearRepository AcademicYearRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _AcademicYearRepository = AcademicYearRepository;
        }

        public async Task<BaseResponse<AcademicYearResponse>> Handle(UpdateAcademicYearCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AcademicYearResponse>();
            //var validator = new UpdateAcademicYearDtoValidator(_AcademicYearRepository);
            //var validationResult = await validator.ValidateAsync(request.UpdateAcademicYearDto);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);
            //response.IsSuccess = false;
            //response.Message = "Update Failed";
            //response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            var AcademicYear = await _unitOfWork.AcademicYearRepository.Get(y => y.Id == request.UpdateAcademicYearDto.Id);
            if (AcademicYear == null)
                throw new NotFoundException(nameof(AcademicYear), request.UpdateAcademicYearDto.Id);

            _mapper.Map(request.UpdateAcademicYearDto, AcademicYear);
            await _unitOfWork.AcademicYearRepository.Update(AcademicYear);
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
