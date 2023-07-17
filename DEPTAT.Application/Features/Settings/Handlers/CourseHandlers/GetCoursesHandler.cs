using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.CourseQuery;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.CourseHandlers
{
    public class GetCoursesHandler : IRequestHandler<GetCoursesQuery, BaseResponseList<CourseResponse>>
    {private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCoursesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<CourseResponse>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<CourseResponse>();
            var CourseList = await _unitOfWork.CourseRepository.GetAll(includes: new List<string> { "Programme" });
            responseList.Result = _mapper.Map<IEnumerable<CourseResponse>>(CourseList);
            responseList.Message = "Success";
            responseList.IsSuccess = true;

            return responseList;
        }
    }
}
