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

namespace DEPTAT.Application.Features.Examinations.Handlers.DebtorsHandler
{
	public class ValidateOTPHandler : IRequestHandler<GetValidateOTPQuery, BaseResponse<OtpResponse>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ValidateOTPHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<BaseResponse<OtpResponse>> Handle(GetValidateOTPQuery request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<OtpResponse>();
			try
			{
				var exist = await _unitOfWork.OtpRepository.Exists(otp=> otp.OtpCode == request._otpCode && otp.StudentNumber == request._studentNumber);
				if (exist)
				{
					response.IsSuccess = true;
					response.Message = "OTP is Valid";
				}
				else
				{
					response.IsSuccess = false;
					response.Message = "INVALID OTP";
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
