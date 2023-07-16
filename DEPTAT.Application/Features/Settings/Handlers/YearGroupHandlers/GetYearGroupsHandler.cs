using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.YearGroupQueries;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.YearGroupHandlers
{
    public class GetYearGroupsHandler : IRequestHandler<GetYearGroupsQueries, BaseResponseList<YearGroupResponse>>
    {private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetYearGroupsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<YearGroupResponse>> Handle(GetYearGroupsQueries request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<YearGroupResponse>();
            var yearGroupList = await _unitOfWork.YearGroupRepository.GetAll();
            responseList.Result = _mapper.Map<IEnumerable<YearGroupResponse>>(yearGroupList);
            responseList.Message = "Success";
            responseList.IsSuccess = true;

            return responseList;
        }
    }
}
