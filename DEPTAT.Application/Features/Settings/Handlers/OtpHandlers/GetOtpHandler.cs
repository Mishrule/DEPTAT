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
    public class GetOtpHandler : IRequestHandler<GetOtpsQuery, BaseResponseList<OtpResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOtpHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<OtpResponse>> Handle(GetOtpsQuery request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<OtpResponse>();
            var otpList = await _unitOfWork.OtpRepository.GetAll(includes: new List<string> { "Student" });
            responseList.Result = _mapper.Map<IEnumerable<OtpResponse>>(otpList);
            responseList.Message = "Success";
            responseList.IsSuccess = true;

            return responseList;
        }
    }
}
