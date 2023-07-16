using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.FacultyQuery;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.FacultyHandlers
{
    public class GetFacultiesHandler : IRequestHandler<GetFacultiesQuery, BaseResponseList<FacultyResponse>>
    {private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFacultiesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<FacultyResponse>> Handle(GetFacultiesQuery request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<FacultyResponse>();
            var FacultyList = await _unitOfWork.FacultyRepository.GetAll();
            responseList.Result = _mapper.Map<IEnumerable<FacultyResponse>>(FacultyList);
            responseList.Message = "Success";
            responseList.IsSuccess = true;

            return responseList;
        }
    }
}
