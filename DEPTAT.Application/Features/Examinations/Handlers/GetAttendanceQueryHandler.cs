using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Examinations.Queries.DebtorQuery;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Examinations.Queries;

namespace DEPTAT.Application.Features.Examinations.Handlers
{
    public class GetAttendanceQueryHandler : IRequestHandler<GetAttendanceQuery, BaseResponseList<AttendanceResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAttendanceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<AttendanceResponse>> Handle(GetAttendanceQuery request, CancellationToken cancellationToken)
        {

            var responseList = new BaseResponseList<AttendanceResponse>();
            responseList.Errors = new List<string>();
            try
            {
                var studentList = await _unitOfWork.AttendanceRepository.GetAll(includes: new List<string> { "Student.Programme.Department.Faculty" });
                responseList.Result = _mapper.Map<IEnumerable<AttendanceResponse>>(studentList);
                responseList.Message = "Success";
                responseList.IsSuccess = true;
            }
            catch (Exception e)
            {
                responseList.IsSuccess = false;
                responseList.Message = e.Message;
                responseList.Errors.Add(e.Message);
            }


            return responseList;
        }
    }
}
