using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Students.Queries.StudentQuery;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Features.Students.Handlers.StudentHandlers
{
	public class GetStudentByProgrammeHandler : IRequestHandler<GetStudentByProgrammeQuery, BaseResponseList<StudentResponse>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetStudentByProgrammeHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<BaseResponseList<StudentResponse>> Handle(GetStudentByProgrammeQuery request, CancellationToken cancellationToken)
		{
			var response = new BaseResponseList<StudentResponse>();
			try
			{
				var student = await _unitOfWork.StudentRepository.GetAll(id => id.Programme.Id == request.ProgrammeId, includes: new List<string> { "Programme.Department.Faculty" });
				response.Result = _mapper.Map<IEnumerable<StudentResponse>>(student);
				response.IsSuccess = true;
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
