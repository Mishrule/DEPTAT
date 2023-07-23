using AutoMapper;
using DEPTAT.Application.Contracts.Infrastructure.Excel;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Examinations.Commands.DebtorsCommand;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Examinations.Commands;
using DEPTAT.Application.DTOs.Course.Validations;

namespace DEPTAT.Application.Features.Examinations.Handlers
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, BaseResponse<AttendanceResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AttendanceResponse>> Handle(CreateAttendanceCommand request,
            CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AttendanceResponse>();

            try
            {
                if (await _unitOfWork.AttendanceRepository.Exists(n => n.AnswerBookSerialNumber == request.CreateAttendanceDto.AnswerBookSerialNumber && n.Semester == request.CreateAttendanceDto.Semester))
                {
                    response.IsSuccess = false;
                    response.Message = "Attendance Already Taken";

                }
                else
                {
                    var attendanceEntity = _mapper.Map<Attendance>(request.CreateAttendanceDto);

                    attendanceEntity = await _unitOfWork.AttendanceRepository.Insert(attendanceEntity);
                    var save = await _unitOfWork.Save();
                    if (save)
                    {
                        response.IsSuccess = true;
                        response.Message = "Attendance Taken Successfully";
                    }
                    else
                    {
                        response.Message = "Attendance Taken Failed, Try again some time";
                        response.IsSuccess = false;
                    }
                }

                
            }
            catch (Exception e)
            {
                response.Message = "Failed: "+ e.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
