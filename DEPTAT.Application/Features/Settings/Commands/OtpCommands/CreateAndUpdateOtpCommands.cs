using DEPTAT.Application.DTOs.AdmittedClass;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Otp;

namespace DEPTAT.Application.Features.Settings.Commands.OtpCommands
{
	public class CreateAndUpdateOtpCommands : IRequest<BaseResponse<OtpResponse>>
	{
		public OtpDto OtpDto { get; set; }
	}
}
