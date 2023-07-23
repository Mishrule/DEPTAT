using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Student.Validations;
using DEPTAT.Application.Exceptions;
using DEPTAT.Application.Features.Students.Commands.StudentCommands;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Examinations.Commands.DebtorsCommand;

namespace DEPTAT.Application.Features.Examinations.Handlers.DebtorsHandler
{
    public class UpdateDebtorsHandler : IRequestHandler<UpdateDebtorCommand, BaseResponse<DebtorsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDebtorsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DebtorsResponse>> Handle(UpdateDebtorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<DebtorsResponse>();

            try
            {
                //var validator = new UpdateStudentDtoValidator();
                //var validationResult = await validator.ValidateAsync(request.UpdateStudentDto);

                //if (validationResult.IsValid == false)
                //{
                //    response.IsSuccess = false;
                //    response.Message = "Update Failed";
                //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                //}


                var student = await _unitOfWork.DebtorRepository.Get(y => y.StudentNumber == request.UpdateDebtorsDto.StudentNumber);
                if (student == null)
                    throw new NotFoundException(nameof(student), request.UpdateDebtorsDto.StudentNumber);

                var entity = _mapper.Map(request.UpdateDebtorsDto, student);
                await _unitOfWork.DebtorRepository.Update(entity);
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
