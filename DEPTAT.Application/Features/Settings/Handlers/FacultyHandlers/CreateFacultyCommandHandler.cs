using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Faculty.Validations;
using DEPTAT.Application.DTOs.YearGroup.Validations;
using DEPTAT.Application.Features.Settings.Commands.FacultyCommands;
using DEPTAT.Application.Features.Settings.Commands.YearGroupCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using FluentValidation;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.YearGroupHandlers
{
    public class CreateFacultyCommandHandler : IRequestHandler<CreateFacultyCommand, BaseResponse<FacultyResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFacultyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<FacultyResponse>> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<FacultyResponse>();
            var validator = new CreateFacultyDtoValidator(_unitOfWork.FacultyRepository);
            var validationResult = await validator.ValidateAsync(request.CreateFacultyDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Operation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                if (await _unitOfWork.FacultyRepository.Exists(n => n.Name == request.CreateFacultyDto.Name))
                {
                    response.IsSuccess = false;
                    response.Message = "Data already Exist";
                    
                }
                else
                {
                    var FacultyEntity = _mapper.Map<Faculty>(request.CreateFacultyDto);

                    FacultyEntity = await _unitOfWork.FacultyRepository.Insert(FacultyEntity);
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
