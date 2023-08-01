using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Course.Validations;
using DEPTAT.Application.Features.Settings.Commands.CourseCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.OtpCommands;
using DEPTAT.Application.Exceptions;
using DEPTAT.Infrastructure;

namespace DEPTAT.Application.Features.Settings.Handlers.OtpHandlers
{
    public class CreateAndUpdateOtpHandler : IRequestHandler<CreateAndUpdateOtpCommands, BaseResponse<OtpResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAndUpdateOtpHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<OtpResponse>> Handle(CreateAndUpdateOtpCommands request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<OtpResponse>();
            var getStudentNumber = await _unitOfWork.StudentRepository.Get(s => s.StudentNumber == request.OtpDto.StudentNumber);
            try
            {
                var exit = await _unitOfWork.OtpRepository.Exists(n => n.StudentNumber == request.OtpDto.StudentNumber && DateTime.Now.Year == request.OtpDto.CurrentYear);
                if (exit)
                {
                    var otp = await _unitOfWork.OtpRepository.Get(y => y.StudentNumber == request.OtpDto.StudentNumber);
                    var id = otp.Id;

                    var otpEntity = _mapper.Map(request.OtpDto, otp);
                    otpEntity.Id = id;
                    await _unitOfWork.OtpRepository.Update(otpEntity);
                    var save = await _unitOfWork.Save();
                    if (save)
                    {

                        response.IsSuccess = true;
                        response.Message = "OTP CLOCKED";
                       
                        SMSGateway.Send($"Use OTP: {otp.OtpCode} Code for this year's exams.", getStudentNumber?.PhoneNumber, "EXAM_CODE");
                    }
                    else
                    {
                        response.Message = "OTP FAILED TO CLOCK";
                        response.IsSuccess = false;
                    }

                }
                else
                {
                    var otpEntity = _mapper.Map<Otp>(request.OtpDto);

                    var otpEnt = await _unitOfWork.OtpRepository.Insert(otpEntity);
                    var save = await _unitOfWork.Save();
                    if (save)
                    {
                        response.IsSuccess = true;
                        response.Message = "OTP CLOCKED";
                        SMSGateway.Send($"Use OTP: ${otpEntity.OtpCode} Code for this year's exams.", getStudentNumber?.PhoneNumber, "EXAM_CODE");
                    }
                    else
                    {
                        response.Message = "OTP FAILED TO CLOCK";
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
