using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Queries.YearGroupQueries;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.YearGroupHandlers
{
    public class GetYearGroupByIdHandler: IRequestHandler<GetYearGroupByIdQuery, BaseResponse<YearGroupResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetYearGroupByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<YearGroupResponse>> Handle(GetYearGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<YearGroupResponse>();
            var yearGroup = await _unitOfWork.YearGroupRepository.Get(id => id.Id == request.Id);
            response.Result = _mapper.Map<YearGroupResponse>(yearGroup);
            response.IsSuccess = true;
            return response;
        }
    }
}
