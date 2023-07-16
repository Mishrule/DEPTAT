using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Queries.AcademicYearQuery;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.AcademicYearHandlers
{
    public class GetAcademicYearByIdHandler: IRequestHandler<GetAcademicYearByIdQuery, BaseResponse<AcademicYearResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAcademicYearByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AcademicYearResponse>> Handle(GetAcademicYearByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AcademicYearResponse>();
            var AcademicYear = await _unitOfWork.AcademicYearRepository.Get(id => id.Id == request.Id);
            response.Result = _mapper.Map<AcademicYearResponse>(AcademicYear);
            response.IsSuccess = true;
            return response;
        }
    }
}
