using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Settings.Queries.OtpQuery
{
	public class GetOtpsQuery : IRequest<BaseResponseList<OtpResponse>>
	{
		public GetOtpsQuery()
		{
		}
	}
}
