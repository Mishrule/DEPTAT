using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.ProgrammeHandlers
{
    public class GetProgrammesHandler : IRequestHandler<GetProgrammesQuery, BaseResponseList<ProgrammeResponse>>
    {private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProgrammesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<ProgrammeResponse>> Handle(GetProgrammesQuery request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<ProgrammeResponse>();
            var ProgrammeList = await _unitOfWork.ProgrammeRepository.GetAll(includes: new List<string> { "Department" });
            responseList.Result = _mapper.Map<IEnumerable<ProgrammeResponse>>(ProgrammeList);
            responseList.Message = "Success";
            responseList.IsSuccess = true;

            return responseList;
        }
    }
}
