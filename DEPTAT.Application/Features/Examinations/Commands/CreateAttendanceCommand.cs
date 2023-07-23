using DEPTAT.Application.DTOs.AdmittedClass;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Examination;

namespace DEPTAT.Application.Features.Examinations.Commands
{
	public class CreateAttendanceCommand : IRequest<BaseResponse<AttendanceResponse>>
	{
		public CreateAttendanceDto CreateAttendanceDto { get; set; }
	}
}
