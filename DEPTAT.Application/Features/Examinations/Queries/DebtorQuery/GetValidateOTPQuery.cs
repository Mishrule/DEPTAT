using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Examinations.Queries.DebtorQuery
{
	public class GetValidateOTPQuery : IRequest<BaseResponse<OtpResponse>>
	{
		public string _studentNumber { get; set; }
		public string _otpCode { get; set; }

		public GetValidateOTPQuery(string studentNumber, string otpCode)
		{
			_studentNumber = studentNumber;
			_otpCode = otpCode;
		}
	}
}
