using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Queries.CourseQuery;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.CourseHandlers
{
    public class GetCourseByIdHandler: IRequestHandler<GetCourseByIdQuery, BaseResponse<CourseResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCourseByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CourseResponse>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CourseResponse>();
            var Course = await _unitOfWork.CourseRepository.Get(id => id.Id == request.Id);
            response.Result = _mapper.Map<CourseResponse>(Course);
            response.IsSuccess = true;
            return response;
        }
    }
}
