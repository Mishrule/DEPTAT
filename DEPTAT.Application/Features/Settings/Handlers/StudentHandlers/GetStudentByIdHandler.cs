
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
using DEPTAT.Application.Features.Settings.Queries.StudentQuery.cs;

namespace DEPTAT.Application.Features.Settings.Handlers.StudentHandlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, BaseResponse<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<StudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<StudentResponse>();
            try
            {
                var student = await _unitOfWork.StudentRepository.Get(id => id.Id == request.Id);
                response.Result = _mapper.Map<StudentResponse>(student);
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
