using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Queries.AdmittedClassQuery;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.AdmittedClassHandlers
{
    public class GetAdmittedClassByIdHandler: IRequestHandler<GetAdmittedClassByIdQuery, BaseResponse<AdmittedClassResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAdmittedClassByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AdmittedClassResponse>> Handle(GetAdmittedClassByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AdmittedClassResponse>();
            var AdmittedClass = await _unitOfWork.AdmittedClassRepository.Get(id => id.Id == request.Id);
            response.Result = _mapper.Map<AdmittedClassResponse>(AdmittedClass);
            response.IsSuccess = true;
            return response;
        }
    }
}
