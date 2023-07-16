using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.YearGroupCommands;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.YearGroup.Validations;
using DEPTAT.Application.Exceptions;

namespace DEPTAT.Application.Features.Settings.Handlers.YearGroupHandlers
{
    public class UpdateYearGroupCommandHandler : IRequestHandler<UpdateYearGroupCommand, BaseResponse<YearGroupResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IYearGroupRepository _yearGroupRepository;

        public UpdateYearGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IYearGroupRepository yearGroupRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _yearGroupRepository = yearGroupRepository;
        }

        public async Task<BaseResponse<YearGroupResponse>> Handle(UpdateYearGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<YearGroupResponse>();
            //var validator = new UpdateYearGroupValidator(_yearGroupRepository);
            //var validationResult = await validator.ValidateAsync(request.UpdateYearGroupDto);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);
            //response.IsSuccess = false;
            //response.Message = "Update Failed";
            //response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            var yearGroup = await _unitOfWork.YearGroupRepository.Get(y => y.Id == request.UpdateYearGroupDto.Id);
            if (yearGroup == null)
                throw new NotFoundException(nameof(yearGroup), request.UpdateYearGroupDto.Id);

            _mapper.Map(request.UpdateYearGroupDto, yearGroup);
            await _unitOfWork.YearGroupRepository.Update(yearGroup);
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
