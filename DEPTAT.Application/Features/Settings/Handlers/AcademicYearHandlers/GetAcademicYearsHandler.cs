using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.AcademicYearQuery;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.AcademicYearHandlers
{
    public class GetAcademicYearsHandler : IRequestHandler<GetAcademicYearsQuery, BaseResponseList<AcademicYearResponse>>
    {private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAcademicYearsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<AcademicYearResponse>> Handle(GetAcademicYearsQuery request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<AcademicYearResponse>();
            var AcademicYearList = await _unitOfWork.AcademicYearRepository.GetAll();
            responseList.Result = _mapper.Map<IEnumerable<AcademicYearResponse>>(AcademicYearList);
            responseList.Message = "Success";
            responseList.IsSuccess = true;

            return responseList;
        }
    }
}
