using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.DepartmentQuery
{
    public class GetDepartmentsQuery:IRequest<BaseResponseList<DepartmentResponse>>
    {
        public GetDepartmentsQuery() { }
    }
}
