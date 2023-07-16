using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.AdmittedClassQuery;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.AdmittedClassHandlers
{
    public class GetAdmittedClasssHandler : IRequestHandler<GetAdmittedClassesQuery, BaseResponseList<AdmittedClassResponse>>
    {private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAdmittedClasssHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<AdmittedClassResponse>> Handle(GetAdmittedClassesQuery request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<AdmittedClassResponse>();
            var AdmittedClassList = await _unitOfWork.AdmittedClassRepository.GetAll();
            responseList.Result = _mapper.Map<IEnumerable<AdmittedClassResponse>>(AdmittedClassList);
            responseList.Message = "Success";
            responseList.IsSuccess = true;

            return responseList;
        }
    }
}
