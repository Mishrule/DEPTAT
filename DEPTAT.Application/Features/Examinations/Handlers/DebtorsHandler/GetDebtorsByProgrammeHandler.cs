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
    public class GetDebtorsByProgrammeHandler : IRequestHandler<GetDebtorsByProgrammeQuery, BaseResponse<DebtorsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDebtorsByProgrammeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DebtorsResponse>> Handle(GetDebtorsByProgrammeQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<DebtorsResponse>();
            try
            {
                var student = await _unitOfWork.DebtorRepository.Get(id => id.Student.ProgrammeId == request._programme, includes: new List<string> { "Student.Programme.Department.Faculty" });
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
