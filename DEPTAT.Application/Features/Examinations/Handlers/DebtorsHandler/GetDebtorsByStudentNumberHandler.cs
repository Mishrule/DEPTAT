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
using DEPTAT.Application.Features.Examinations.Queries.DebtorQuery;

namespace DEPTAT.Application.Features.Examinations.Handlers.DebtorsHandler
{
    public class GetDebtorsByStudentNumberHandler : IRequestHandler<GetDebtorsByStudentNumberQuery, BaseResponse<DebtorsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDebtorsByStudentNumberHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DebtorsResponse>> Handle(GetDebtorsByStudentNumberQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<DebtorsResponse>();
            try
            {
                var student = await _unitOfWork.DebtorRepository.Get(id => id.StudentNumber == request._studentNumber, includes: new List<string> { "Student.Programme.Department.Faculty" });
                response.Result = _mapper.Map<DebtorsResponse>(student);
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
