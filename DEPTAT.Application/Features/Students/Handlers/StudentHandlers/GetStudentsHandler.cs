using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Students.Queries.StudentQuery;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Students.Handlers.StudentHandlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, BaseResponseList<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<StudentResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {

            var responseList = new BaseResponseList<StudentResponse>();
            try
            {
                var studentList = await _unitOfWork.StudentRepository.GetAll(includes: new List<string> { "Programme.Department.Faculty" });
                responseList.Result = _mapper.Map<IEnumerable<StudentResponse>>(studentList);
                responseList.Message = "Success";
                responseList.IsSuccess = true;
            }
            catch (Exception e)
            {
                responseList.Errors.Add(e.Message);
            }
            

            return responseList;
        }
    }
}
