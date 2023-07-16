using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Queries.FacultyQuery;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.FacultyHandlers
{
    public class GetFacultyByIdHandler: IRequestHandler<GetFacultyByIdQuery, BaseResponse<FacultyResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFacultyByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<FacultyResponse>> Handle(GetFacultyByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<FacultyResponse>();
            var Faculty = await _unitOfWork.FacultyRepository.Get(id => id.Id == request.Id);
            response.Result = _mapper.Map<FacultyResponse>(Faculty);
            response.IsSuccess = true;
            return response;
        }
    }
}
