using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.ProgrammeHandlers
{
    public class GetProgrammeByIdHandler: IRequestHandler<GetProgrammeByIdQuery, BaseResponse<ProgrammeResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProgrammeByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProgrammeResponse>> Handle(GetProgrammeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProgrammeResponse>();
            var Programme = await _unitOfWork.ProgrammeRepository.Get(id => id.Id == request.Id);
            response.Result = _mapper.Map<ProgrammeResponse>(Programme);
            response.IsSuccess = true;
            return response;
        }
    }
}
