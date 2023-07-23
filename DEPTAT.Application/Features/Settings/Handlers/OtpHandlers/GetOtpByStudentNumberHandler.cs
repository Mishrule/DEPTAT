using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Queries.OtpQuery;

namespace DEPTAT.Application.Features.Settings.Handlers.OtpHandlers
{
    public class GetOtpByStudentNumberHandler : IRequestHandler<GetOtpByStudentNumberQuery, BaseResponse<OtpResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOtpByStudentNumberHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<OtpResponse>> Handle(GetOtpByStudentNumberQuery request,
            CancellationToken cancellationToken)
        {
            var response = new BaseResponse<OtpResponse>();
            var otp = await _unitOfWork.OtpRepository.Get(id => id.StudentNumber == request.studentNumber);
            response.Result = _mapper.Map<OtpResponse>(otp);
            response.IsSuccess = true;
            return response;
        }
    }
}
