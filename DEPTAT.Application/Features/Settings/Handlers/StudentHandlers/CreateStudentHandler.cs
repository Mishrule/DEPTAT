using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Programme.Validations;
using DEPTAT.Application.Features.Settings.Commands.ProgrammeCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Student.Validations;
using DEPTAT.Application.Features.Settings.Commands.StudentCommands;

namespace DEPTAT.Application.Features.Settings.Handlers.StudentHandlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, BaseResponse<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<StudentResponse>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<StudentResponse>();
            try
            {
                var validator = new CreateStudentDtoValidator(_unitOfWork.StudentRepository);
                var validationResult = await validator.ValidateAsync(request.CreateStudentDto);

                if (validationResult.IsValid == false)
                {
                    response.IsSuccess = false;
                    response.Message = "Operation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }
                else
                {
                    if (await _unitOfWork.StudentRepository.Exists(n => n.IndexNumber == request.CreateStudentDto.IndexNumber))
                    {
                        response.IsSuccess = false;
                        response.Message = "Student already Exist";

                    }

                    var studentEntity = _mapper.Map<Student>(request.CreateStudentDto);

                    studentEntity = await _unitOfWork.StudentRepository.Insert(studentEntity);
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
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }

            
           

            return response;
        }
    }
}
