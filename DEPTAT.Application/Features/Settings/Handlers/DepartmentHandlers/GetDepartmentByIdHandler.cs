using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Queries.DepartmentQuery;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.DepartmentHandlers
{
    public class GetDepartmentByIdHandler: IRequestHandler<GetDepartmentByIdQuery, BaseResponse<DepartmentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<DepartmentResponse>();
            var Department = await _unitOfWork.DepartmentRepository.Get(id => id.Id == request.Id);
            response.Result = _mapper.Map<DepartmentResponse>(Department);
            response.IsSuccess = true;
            return response;
        }
    }
}
