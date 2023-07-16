using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.DepartmentQuery
{
    public class GetDepartmentQuery:IRequest<BaseResponseList<DepartmentResponse>>
    {
        public GetDepartmentQuery() { }
    }
}
